using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
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
                if(Session["email"].ToString().Equals("vadillo@ehu.es"))
                {
                    FormsAuthentication.SetAuthCookie("Vadillo", false);
                    Session["usuario"] = "Vadillo";
                }
                else
                {
                    FormsAuthentication.SetAuthCookie("Profesor", false);
                    Session["usuario"] = "Profesor";
                }
                ((ArrayList)Application["ProfesorList"]).Add(Session["email"].ToString());
                Response.Redirect("Profesor/Profesor.aspx");
            }
            else {
                FormsAuthentication.SetAuthCookie("Alumno", false);
                Session["usuario"] = "Alumno";
                ((ArrayList)Application["AlumnoList"]).Add(Session["email"].ToString());
                Response.Redirect("Alumno/Alumno.aspx");
            }
            
        }
    }
}