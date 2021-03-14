using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADS_IBER_EVAR
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAnadir_Click(object sender, EventArgs e)
        {
            //coger datos de los controles y pasar como params
            DataTable table = new DataTable();

            int horas;
            if (int.TryParse(tbHrsEstimadas.Text, out horas))
            {
                SqlConnection connection = new SqlConnection(Lab3.DataAccess.getConnectionString());

                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM TareasGenericas", connection);
                sda.InsertCommand = new SqlCommand("INSERT INTO TareasGenericas VALUES(@codigo, @descripcion,@codAsig, @hEstimadas, @explotacion, @tipoTarea)", connection);
                sda.InsertCommand.Parameters.Add("@codigo", SqlDbType.NVarChar, 50, "Codigo");
                sda.InsertCommand.Parameters.Add("@descripcion", SqlDbType.NVarChar, 50, "Descripcion");
                sda.InsertCommand.Parameters.Add("@codAsig", SqlDbType.NVarChar, 50, "CodAsig");
                sda.InsertCommand.Parameters.Add("@hEstimadas", SqlDbType.Int, 10, "HEstimadas");
                sda.InsertCommand.Parameters.Add("@explotacion", SqlDbType.Bit, 1, "explotacion");
                sda.InsertCommand.Parameters.Add("@tipoTarea", SqlDbType.NVarChar, 50, "TipoTarea");

                sda.Fill(table);
                table.Rows.Add(tbCodigo.Text, tbDescripcion.Text, dlAsignaturas.SelectedValue, horas, false, dlTipo.SelectedValue);
                sda.Update(table);
                Correcto.Visible = true;
                ERROR.Visible = false;
                tbCodigo.Text = "";
                tbDescripcion.Text = "";
                tbHrsEstimadas.Text = "";
            }
            else
            {
                Correcto.Visible = false;
                ERROR.Visible = true;
            }
        }

        protected void dlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}