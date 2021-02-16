using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab3
{
    public class DataAccess
    {
        private const string connectionString = "Server=tcp:hads21-19.database.windows.net,1433;Initial Catalog=HADS21-19;Persist Security Info=False;User ID=iberganza004@ikasle.ehu.eus@hads21-19;Password=deLOCOS!!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static void registrarUsuario(String emilio, String nombre, String apellidos, int numConfir, Boolean confirmado, String tipo, String pass)
        {
            string queryString = "INSERT into dbo.Usuarios (email,nombre,apellidos, numconfir, confirmado, tipo, pass) " +
                "VALUES (@email,@nombre,@apellidos,@numconfir,@confirmado,@tipo,@pass)";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString,connection);
                command.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = emilio;
                command.Parameters.Add("@nombre", SqlDbType.NVarChar, 30).Value = nombre;
                command.Parameters.Add("@apellidos", SqlDbType.NVarChar, 30).Value = apellidos;
                command.Parameters.Add("@numconfir", SqlDbType.Int, 30).Value = numConfir;
                command.Parameters.Add("@confirmado", SqlDbType.Bit, 30).Value = confirmado;
                command.Parameters.Add("@tipo", SqlDbType.NVarChar, 30).Value = tipo;
                command.Parameters.Add("@pass", SqlDbType.NVarChar, 30).Value = pass;
                command.Connection.Open();
                command.ExecuteNonQuery();
                
            }


        }
        public static Boolean iniciarSesion(String emilio, String pass)
        {
            string queryString = "SELECT email from dbo.Usuarios WHERE (email = @email AND pass = @pass)";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = emilio;
                command.Parameters.Add("@pass", SqlDbType.NVarChar, 30).Value = pass;
                command.Connection.Open();

                try
                {
                    String e = (string)command.ExecuteScalar();
                    if (e == emilio)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error de contraseña");
                    Console.WriteLine(ex.Message);
                }
                return false;
            }

        }
        public static void introducirClaveRecuperacion(String emilio, int codpass)
        {
            string queryString = "UPDATE dbo.Usuarios SET codpass = @codpass WHERE email = @emilio";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@codpass", SqlDbType.Int, 30).Value = codpass;
                command.Parameters.Add("@emilio", SqlDbType.NVarChar, 30).Value = emilio;
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }

        }
        public static Boolean comprobarClave(String emilio, String codpass)
        {
            string queryString = "SELECT email from dbo.Usuarios WHERE (email = @email AND codpass = @codpass)";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = emilio;
                command.Parameters.Add("@codpass", SqlDbType.NVarChar, 30).Value = codpass;
                command.Connection.Open();

                try
                {
                    String e = (string)command.ExecuteScalar();
                    if (e == emilio)
                    {

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error de contraseña");
                    Console.WriteLine(ex.Message);
                }
                return false;
            }

        }

        public static void modificarContraseña(String emilio, String newPass) {
            string queryString = "UPDATE dbo.Usuarios SET pass = @pass WHERE email = @emilio";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@pass", SqlDbType.Int, 30).Value = newPass;
                command.Parameters.Add("@emilio", SqlDbType.NVarChar, 30).Value = emilio;
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }
    }

}
