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
            Label7.Visible = false;
            tbRespuesta.Visible = false;
            rfvRespuesta.Visible = false;
        }

        protected void btnSolicitarCambio_Click(object sender, EventArgs e)
        {

            try
            {
                var fromAddress = new MailAddress("hads21.19@gmail.com", "HADS21 - Grupo 19");
                var toAddress = new MailAddress(tbEmail.Text, "Welcome");
                Random rnd = new Random();
                int clave = rnd.Next(111111, 999999);
                Lab3.DataAccess.introducirClaveRecuperacion(tbEmail.Text, clave);
                const string subject = "Cambiar mi contraseña";
                string body = String.Concat("El código para modificar tu password es: ", clave);
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
                Label7.Visible = true;
                tbRespuesta.Visible = true;
                rfvRespuesta.Visible = true;
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
            if (Lab3.DataAccess.modificarContraseña(tbEmail.Text, tbPassword.Text))
            {

                lblFeedback0.Text = "Clave modificada con éxito";
                Server.Transfer("Inicio.aspx");

            }
            else
            {
                lblFeedback0.Text = "Vaya, la clave no se ha modificado con éxito";

            }

        }
    }
}