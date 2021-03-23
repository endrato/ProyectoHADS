using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADS_IBER_EVAR
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String tipo = Lab4.ADO.getTipo(Session["email"].ToString());
            if ( tipo == "Profesor")
            {
                Response.Redirect("Profesor/Profesor.aspx");
            }
            else {
                Response.Redirect("Alumno/Alumno.aspx");
            
            }
        }

    }
}