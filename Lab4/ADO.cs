using System;
using System.Data.SqlClient;

namespace Lab4
{
    public class ADO
    {

        private const string connectionString = "Server=tcp:hads21-19.database.windows.net,1433;Initial Catalog=HADS21-19;Persist Security Info=False;User ID=iberganza004@ikasle.ehu.eus@hads21-19;Password=deLOCOS!!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static String getTipo(String emilio)
        {
            string queryString = "SELECT tipo from dbo.Usuarios WHERE (email = @email)";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 30).Value = emilio;
                command.Connection.Open();
                try
                {
                    return (String)command.ExecuteScalar();
                }
                catch (Exception e)
                {
                    Console.Write(e.StackTrace);
                    Console.Write("Fallo en getTipo");
                    return "";
                }


            }

        }
    }
}
