using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADS_IBER_EVAR.Profesor.Vadillo
{
    public partial class coordinador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMedia_Click(object sender, EventArgs e)
        {
            Medias.ServiceClient medias = new Medias.ServiceClient();

            try {
                double media = medias.obtenerMedia(dlAsignaturas.Text);
                if (media == 0)
                {
                    lblMedia.Text = "No hay información";
                }
                else
                {
                    lblMedia.Text = "La media es: "+media.ToString();
                }
            }

            catch (Exception)
            {
                lblMedia.Text = "No hay información";
            }
        
        }
    }
}