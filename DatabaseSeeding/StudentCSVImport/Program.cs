using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace StudentCSVImport
{
     class Program
    {
        static void Main(string[] args)
        {
            var lineNumber = 0;
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RDT234N\SQLEXPRESS;Integrated Security=true"))
            {
                conn.Open();
                using (StreamReader reader = new StreamReader(@"C:\Users\Admin\New folder\StudentCSVFile.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if(lineNumber !=0)
                        {

                            var values = line.Split(',');

                            var sql = "INSERT INTO CSVImport.dbo.Student_Table Values('" + values[0] + "','" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4] + "','" + values[5] + "','" + values[6] + "','" + values[7] + "','" + values[8] + "','" + values[9] + "','" + values[10] + "','" + values[11] + "','" + values[12] + "','" + values[13] + "','" + values[14] + "','" + values[15] + "','" + values[16] + "','" + values[17] + "','" + values[18] +"')";

                            var cmd = new SqlCommand();
                            cmd.CommandText = sql;
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                        }
                        lineNumber++;

                    }
                   
                }
                conn.Close();
                Console.WriteLine("Student data mport completed");
                Console.ReadLine();
            }
               
        }
    }
}
