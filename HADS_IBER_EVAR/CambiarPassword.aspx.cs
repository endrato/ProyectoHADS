using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace HADS_IBER_EVAR
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label6.Visible = false;
            Label5.Visible = false;
            tbPassword.Visible = false;
            tbRepPassword.Visible = false;
            btnModificarContraseña.Visible = false;
            rfvPass.Visible = false;
            rfvRePass.Visible = false;
            cvPass.Visible = false;
        }

        protected void btnSolicitarCambio_Click(object sender, EventArgs e)
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("hads21.19@gmail.com");
                mail.To.Add(tbEmail.Text);
                mail.Subject = "Cambiar password";
                Random rnd = new Random();
                int clave = rnd.Next(111111,999999);
                Lab3.DataAccess.introducirClaveRecuperacion(tbEmail.Text,clave);
                mail.Body = String.Concat("El código para modificar tu password es", clave);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hads21.19","deLOCOS!!!");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //MessageBox.Show(ex.ToString());
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (Lab3.DataAccess.comprobarClave(tbEmail.Text, tbRespuesta.Text))
            {
                lblFeedback.Text = "Clave correcta, introduce tu nueva contraseña";
                Label6.Visible = true;
                Label5.Visible = true;
                tbPassword.Visible = true;
                tbRepPassword.Visible = true;
                btnModificarContraseña.Visible = true;
                rfvPass.Visible = true;
                rfvRePass.Visible = true;
                cvPass.Visible = true;

            }
            else {
                lblFeedback.Text = "Vaya, la clave no es correcta";
                


            }
        }

        protected void btnModificarContraseña_Click(object sender, EventArgs e)
        {

        }
    }
}