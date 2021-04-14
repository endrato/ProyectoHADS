using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Collections;

namespace HADS_IBER_EVAR
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["AlumnoList"] = new ArrayList();
            Application["ProfesorList"] = new ArrayList(); 
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["usuario"] = "";
            Session["email"] = "";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            String tipo = Lab4.ADO.getTipo(Session["email"].ToString());
            if (tipo == "Profesor")
            {
                ((ArrayList)Application["ProfesorList"]).Remove(Session["email"].ToString());
            }
            else
            {
                ((ArrayList)Application["AlumnoList"]).Remove(Session["email"].ToString());
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            ((ArrayList)Application["AlumnoList"]).Clear();
            ((ArrayList)Application["ProfesorList"]).Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
        }
    }
}