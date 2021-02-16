using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace HADS_IBER_EVAR
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rbtnProfesor_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int numConfir = rnd.Next(1111111, 9999999);
            String tipo = "alumno";
            if (rbtnProf.Checked) {
                tipo = "profesor";
            }
            Lab3.DataAccess.registrarUsuario(tbEmail.Text, tbNombre.Text, tbApellidos.Text, numConfir, false, tipo, tbPassword.Text);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("hads21.19@gmail.com");
                mail.To.Add(tbEmail.Text);
                mail.Subject = "Confirmar cuenta";
                mail.Body = String.Concat("Haz clic aqui para confirmar tu cuenta : http://localhost/PracticaHAS/confirmar.aspx?mbr=pepe@pepe.pepe&numconf=9715284 ");

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hads21.19", "deLOCOS!!!");
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
    }
}