using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADS_IBER_EVAR
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Lab3.DataAccess.iniciarSesion(tbEmail.Text, tbPassword.Text))
            {
                Session["email"] = tbEmail.Text;
                
                Server.Transfer("Principal.aspx");

                Console.WriteLine("Login correcto");

            }
            else {
                Label3.Text = "Contraseña incorrecta o usuario sin confirmar";
            }
        }
    }
}