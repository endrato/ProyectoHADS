using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            if (tipo == "Vadillo")
            {
                HyperLink2.Visible = true;
                HyperLink3.Visible = true;
            }
            else
            {
                HyperLink2.Visible = false;
                HyperLink3.Visible = false;
            }
            ArrayList alumnos = ((ArrayList)Application["AlumnoList"]);
            ArrayList profesores = ((ArrayList)Application["ProfesorList"]);
            if (profesores.Count > 0)
            {
                numProf.Text = profesores.Count.ToString();
                contProfesores.Visible = true;
            }
            else
            {
                contProfesores.Visible = false;
            }

            if (alumnos.Count > 0)
            {
                numAlums.Text = alumnos.Count.ToString();
                contAlumnos.Visible = true;
            }
            else
            {
                contAlumnos.Visible = false;
            }

            DataSet profesoresSet = GetDsFromArray(profesores.ToArray());
            profesoresListView.DataSource = profesoresSet.Tables[0];
            profesoresListView.DataBind();

            DataSet alumnosSet = GetDsFromArray(alumnos.ToArray());
            alumnosListView.DataSource = alumnosSet.Tables[0];
            alumnosListView.DataBind();
        }
        private DataSet GetDsFromArray(Object[] list)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("EmailList", Type.GetType("System.String")));
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["EmailList"] = list[i].ToString();
                dt.Rows.Add(dr);

            }

            ds.Tables.Add(dt);
            return ds;

        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {

        }

        protected void profesoresListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}