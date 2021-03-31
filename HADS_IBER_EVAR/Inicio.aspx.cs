using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        private String getCriptoPass(string pass)
        {
            MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();

            byte[] hashedPass = hash.ComputeHash(Encoding.Default.GetBytes(pass));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hashedPass.Length; i++)
                stringBuilder.Append(hashedPass[i].ToString("x2"));
            return stringBuilder.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String passCod = getCriptoPass(tbPassword.Text);
            if (Lab3.DataAccess.iniciarSesion(tbEmail.Text, passCod))
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