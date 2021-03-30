using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace HADS_IBER_EVAR.Profesor.Vadillo
{
    public partial class ExportarTareasXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dlAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFeedback.Text = "";

            string sql = "SELECT * FROM TareasGenericas WHERE CodAsig='" + dlAsignaturas.SelectedValue + "'";
            SqlConnection connection = new SqlConnection(Lab3.DataAccess.getConnectionString());
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            DataSet ds = new DataSet("tareas");
            adapter.Fill(ds, "tarea");
            Session["tablaTareas"] = ds;
            Session["adapterTareas"] = adapter;
            gvTareas.DataSource = ds;
            gvTareas.DataBind();
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            if (dlAsignaturas.SelectedValue != "-1")
            {
                string path = "../App_Data/" + dlAsignaturas.SelectedValue + ".xml";
                if (!File.Exists(Server.MapPath(path)))
                {
                    try
                    {
                        File.Create(Server.MapPath(path)).Close();

                    }
                    catch (IOException ex)
                    {
                        lblFeedback.Text = "Error al crear el archivo";
                    }
                }
                try
                {
                    createXmlFile(path);
                    lblFeedback.Text = "Archivo creado correctamente";
                }
                catch (Exception ex)
                {
                    lblFeedback.Text = "Vaya, ha habido un errorcillo";
                }

            }
            else
            {
                lblFeedback.Text = "Escoge una asignatura valida";
            }

        }

        private void createXmlFile(String path)
        {

            DataSet ds = (DataSet)Session["tablaTareas"];
            SqlDataAdapter adapter = (SqlDataAdapter)Session["adapterTareas"];
            ds.Tables[0].Columns[0].ColumnMapping = MappingType.Attribute;
            ds.WriteXml(Server.MapPath("../App_Data/" + dlAsignaturas.SelectedValue + ".xml"));
        }
    }
}