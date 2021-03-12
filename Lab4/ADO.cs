using System;
using System.Data;
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

        public static void insertarTarea() {
            DataTable table = new DataTable();

            int horas;
            if (int.TryParse(horasEstimadas.Text, out horas))
            {
                SqlConnection connection = new SqlConnection(connectionString);

                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM TareasGenericas", connection);
                sda.InsertCommand = new SqlCommand("INSERT INTO TareasGenericas VALUES(@codigo, @descripcion,@codAsig, @hEstimadas, @explotacion, @tipoTarea)", connection);
                sda.InsertCommand.Parameters.Add("@codigo", SqlDbType.NVarChar, 50, "Codigo");
                sda.InsertCommand.Parameters.Add("@descripcion", SqlDbType.NVarChar, 50, "Descripcion");
                sda.InsertCommand.Parameters.Add("@codAsig", SqlDbType.NVarChar, 50, "CodAsig");
                sda.InsertCommand.Parameters.Add("@hEstimadas", SqlDbType.Int, 10, "HEstimadas");
                sda.InsertCommand.Parameters.Add("@explotacion", SqlDbType.Bit, 1, "explotacion");
                sda.InsertCommand.Parameters.Add("@tipoTarea", SqlDbType.NVarChar, 50, "TipoTarea");

                sda.Fill(table);
                table.Rows.Add(codigo.Text, descripcion.Text, asignaturas.SelectedValue, horas, false, tipoTarea.SelectedValue);
                sda.Update(table);
                //Mostrar Mensaje de todo guay.
                todoGuayAlert.Visible = true;
                horasNumero.Visible = false;
            }
            else
            {//Mostrar error de que las horas introducidas son incorrectas
                todoGuayAlert.Visible = false;
                horasNumero.Visible = true;

            }
        } 
    }
}
