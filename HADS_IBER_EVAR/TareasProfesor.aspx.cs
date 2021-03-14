using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADS_IBER_EVAR
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertarTarea.aspx");
        }

        protected void gvTareasProf_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void dlAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}