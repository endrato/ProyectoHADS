using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADS_IBER_EVAR.Profesor
{
    public partial class Profesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String tipo = Session["usuario"].ToString();
            if(tipo == "Vadillo")
            {
                HyperLink2.Visible = true;
                HyperLink3.Visible = true;
            }
            else
            {
                HyperLink2.Visible = false;
                HyperLink3.Visible = false;
            }
        }
    }
}