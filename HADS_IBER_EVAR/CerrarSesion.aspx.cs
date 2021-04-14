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
    public partial class CerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((ArrayList)Application["AlumnoList"]).Contains(Session["email"].ToString()))
            {
                ((ArrayList)Application["AlumnoList"]).Remove(Session["email"].ToString());
            }
            else
            {
                ((ArrayList)Application["ProfesorList"]).Remove(Session["email"].ToString());
            }
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("Inicio.aspx");

        }
    }
}