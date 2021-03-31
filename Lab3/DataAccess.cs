using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab3
{
    public class DataAccess
    {
        private const string connectionString = "Server=tcp:hads21-19.database.windows.net,1433;Initial Catalog=HADS21-19;Persist Security Info=False;User ID=iberganza004@ikasle.ehu.eus@hads21-19;Password=deLOCOS!!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static string getConnectionString()
        {
            return connectionString;
        }
        public static Boolean tareaRepe(String email, String cod)
        {
            Boolean esta = false;
            string queryString = "SELECT * FROM EstudiantesTareas WHERE Email='" + email + "' AND CodTarea='" + cod + "'";

            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                try
                {
                    SqlDataReader dr = command.ExecuteReader();
                    command.Connection.Close();
                    if (dr.Read())
                    {
                        esta = true;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error ");
                    Console.WriteLine(ex.Message);
                }
                esta = false;
            }
            return esta;
        }
        public static int insertarTarea(String email,String cod,String horasE,String horasR)
        {
            String queryString = "INSERT INTO EstudiantesTareas VALUES('" + email + "', '" + cod + "'," + horasE + " ," + horasR + " )";
            int resul = 0;
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                try
                {
                    resul = command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error ");
                    Console.WriteLine(ex.Message);
                }
            }
                
            return resul;
        }
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
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e) {
                    Console.Write(e.StackTrace);
                    Console.Write("Ya existe usuario con ese email");
                }
                
                
            }

        }
        public static Boolean iniciarSesion(String emilio, String pass)
        {
            string queryString = "SELECT pass from dbo.Usuarios WHERE (email = @email AND confirmado = 'True')";
           
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = emilio;
                command.Connection.Open();
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                try
                {
                    String e = (string)command.ExecuteScalar();
                    command.Connection.Close();
                    if (0 == comparer.Compare(pass, e))
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
                command.Parameters.Add("@codpass", SqlDbType.Int, 32).Value = Convert.ToInt32(codpass);
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
        public static Boolean modificarContraseña(String emilio, String newPass) {
            string queryString = "UPDATE dbo.Usuarios SET pass = @pass WHERE email = @emilio";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@pass", SqlDbType.NVarChar, 30).Value = newPass;
                command.Parameters.Add("@emilio", SqlDbType.NVarChar, 30).Value = emilio;
                command.Connection.Open();
                try {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return false;
                }
                
                //command.Connection.Close();
            }
        }
        public static Boolean confirmarUsuario(String emilio, int numConfir)
        {
            string queryString1 = "SELECT numconfir from dbo.Usuarios WHERE email = @emilio";
            string queryString2 = "UPDATE dbo.Usuarios SET confirmado = 'true' WHERE email = @emilio";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand select = new SqlCommand(queryString1, connection);
                select.Parameters.Add("@emilio", SqlDbType.NVarChar, 30).Value = emilio;
                select.Connection.Open();
                int numConfirBD = (int)select.ExecuteScalar();
                select.Connection.Close();

                if (numConfirBD == numConfir)
                {
                    SqlCommand update = new SqlCommand(queryString2, connection);
                    update.Parameters.Add("@emilio", SqlDbType.NVarChar, 30).Value = emilio;
                    update.Connection.Open();
                    try
                    {
                        update.ExecuteNonQuery();
                        update.Connection.Close();
                        return true;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                        return false;
                    }

                }
                else {
                    Console.WriteLine("Número de confirmación no coincide con el de la BD");
                    return false;
                }
            }

        }
    }

}
