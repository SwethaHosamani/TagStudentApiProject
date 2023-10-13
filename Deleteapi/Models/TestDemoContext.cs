using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Deleteapi.Models;

public partial class TestDemoContext : DbContext
{
    public TestDemoContext()
    {
    }

    public TestDemoContext(DbContextOptions<TestDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentDatum> StudentData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        
    if(!optionsBuilder.IsConfigured){
         optionsBuilder.UseSqlServer("Server=DESKTOP-RDT234N\\SQLEXPRESS;Database=TestDemo;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;");
    }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentDatum>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.Gender });

            entity.Property(e => e.StudentId)
                .HasMaxLength(50)
                .HasColumnName("Student_ID");
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Classes).HasMaxLength(50);
            entity.Property(e => e.GradeId)
                .HasMaxLength(50)
                .HasColumnName("GradeID");
            entity.Property(e => e.Nationlity).HasMaxLength(50);
            entity.Property(e => e.ParentAnsweringSurvey).HasMaxLength(50);
            entity.Property(e => e.ParentschoolSatisfaction).HasMaxLength(50);
            entity.Property(e => e.PlaceOfBirth).HasMaxLength(50);
            entity.Property(e => e.Relation).HasMaxLength(50);
            entity.Property(e => e.SectionId)
                .HasMaxLength(50)
                .HasColumnName("SectionID");
            entity.Property(e => e.Semester).HasMaxLength(50);
            entity.Property(e => e.StageId)
                .HasMaxLength(50)
                .HasColumnName("StageID");
            entity.Property(e => e.StudentAbsenceDays).HasMaxLength(50);
            entity.Property(e => e.Topic).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
