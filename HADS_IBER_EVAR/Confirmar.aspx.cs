using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADS_IBER_EVAR
{
    public partial class Confirmar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String emilio = Request.Params.Get("emilio");
            int numConfir = Convert.ToInt32(Request.Params.Get("numConfir"));
            if (Lab3.DataAccess.confirmarUsuario(emilio, numConfir)) 
            {
                Server.Transfer("Inicio.aspx");
            }
        }
    }
}