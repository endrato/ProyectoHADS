using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Microsoft.Web.Administration;
using System.Security.Cryptography;
using System.Text;

namespace HADS_IBER_EVAR
{
    public partial class WebForm2 : System.Web.UI.Page
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

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int numConfir = rnd.Next(1111111, 9999999);
            String tipo = "alumno";
            if (rbtnProf.Checked) {
                tipo = "profesor";
            }
            String pass = getCriptoPass(tbPassword.Text);
            Lab3.DataAccess.registrarUsuario(tbEmail.Text, tbNombre.Text, tbApellidos.Text, numConfir, false, tipo, pass);
            try
            {
                var fromAddress = new MailAddress("hads21.19@gmail.com", "HADS21 - Grupo 19");
                var toAddress = new MailAddress(tbEmail.Text, "Welcome");
               
                const string subject = "Confirmar tu cuenta";
                string enlace = Convert.ToString("http://hads21-19.azurewebsites.net/Confirmar.aspx?emilio=" + tbEmail.Text+"&numConfir="+numConfir);
                string body = "Clica el siguiente link para confirmar tu cuenta:\n" + enlace;

             var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential("hads21.19", "deLOCOS!!!"),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                
                lblRegistrado.Text = "Se ha mandado un email de confirmación a " + tbEmail.Text;
                Server.Transfer("Inicio.aspx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //MessageBox.Show(ex.ToString());
            }

        }
    }
}