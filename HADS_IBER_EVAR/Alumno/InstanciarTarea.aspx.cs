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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbUsuario.Text = Session["email"].ToString();
            tbTarea.Text = Request.QueryString["codigo"];
            tbHrsEst.Text = Request.QueryString["horas"];
            creargridview();

        }
        private void creargridview()
        {
            string sql = "SELECT Email, CodTarea, HEstimadas AS Horas_Estimadas, HReales AS Horas_Reales FROM EstudiantesTareas WHERE Email='" + Session["email"] + "'";
            SqlConnection connection = new SqlConnection(Lab3.DataAccess.getConnectionString());

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            gvTareas.DataSource = ds;
            gvTareas.DataBind();

        }

        private Boolean tareaRepe()
        {
            Boolean esta=false;
            String email = Session["email"].ToString(); 
            esta=Lab3.DataAccess.tareaRepe(email, tbTarea.Text);
            return esta;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string horasString = tbHrsReal.Text;
            int horas;
            if (int.TryParse(horasString, out horas))
            {
                if (!tareaRepe())
                {
                    
                    int numRegs = Lab3.DataAccess.insertarTarea(Session["email"].ToString(),tbTarea.Text,tbHrsEst.Text,tbHrsReal.Text);
                    if (numRegs == 1)
                    {//Todo guay
                        Correcto.Visible = true;
                        ErrorRegistro.Visible = false;
                        formatoHoras.Visible = false;
                        TareaRepeAlerta.Visible = false;
                        creargridview();
                        tbHrsReal.ReadOnly = true;
                    }
                    else
                    {//algo ha ido mal
                        ErrorRegistro.Visible = true;
                        formatoHoras.Visible = false;
                        TareaRepeAlerta.Visible = false;
                        Correcto.Visible = false;
                    }
                }
                else
                {//Error tarea ya instanciada
                    TareaRepeAlerta.Visible = true;
                    ErrorRegistro.Visible = false;
                    formatoHoras.Visible = false;
                    Correcto.Visible = false;
                }
            }
            else
            {//Mostrar error de que las horas introducidas no son correctas.
                formatoHoras.Visible = true;
                ErrorRegistro.Visible = false;
                TareaRepeAlerta.Visible = false;
                Correcto.Visible = false;
            }
        }
    }
}