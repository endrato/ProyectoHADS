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
    public partial class TareasAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            actualizargrid();
            
            
        }
        private void actualizargrid()
        {
            DataTable table = new DataTable();
            string sql = "SELECT Codigo, Descripcion, HEstimadas AS Horas, TipoTarea AS Tipo FROM TareasGenericas WHERE CodAsig='" + dlAsig.SelectedValue + "' AND Explotacion=1";
            SqlConnection connection = new SqlConnection(Lab3.DataAccess.getConnectionString());
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(table);
            gvTareasAlum.DataSource = table;
            gvTareasAlum.DataBind();
        }

        protected void gvTareasAlum_SelectedIndexChanged(object sender, EventArgs e)
        {
            String codigo = gvTareasAlum.SelectedRow.Cells[1].Text;
            String horas = gvTareasAlum.SelectedRow.Cells[3].Text;

            Response.Redirect("InstanciarTarea.aspx?codigo=" + codigo + "&horas=" + horas + "");
        }

        protected void dlAsig_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}