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

namespace HADS_IBER_EVAR.Profesor
{
    public partial class ImportarTareasXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            if (dlAsignaturas.SelectedValue != "-1")
            {
                lblFeedback.Text = "";
                try
                {
                    XmlDocument xml = new XmlDocument();

                    SqlConnection connection = new SqlConnection(Lab3.DataAccess.getConnectionString());
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TareasGenericas WHERE CodAsig='" + dlAsignaturas.SelectedValue + "'", connection);
                    adapter.InsertCommand = new SqlCommand("INSERT INTO TareasGenericas VALUES(@codigo, @descripcion, @codAsig, @hEstimadas, @explotacion, @tipoTarea)", connection);
                    adapter.InsertCommand.Parameters.Add("@codigo", SqlDbType.NVarChar, 50, "Codigo");
                    adapter.InsertCommand.Parameters.Add("@descripcion", SqlDbType.NVarChar, 50, "Descripcion");
                    adapter.InsertCommand.Parameters.Add("@codAsig", SqlDbType.NVarChar, 50, "CodAsig");
                    adapter.InsertCommand.Parameters.Add("@hEstimadas", SqlDbType.Int, 10, "HEstimadas");
                    adapter.InsertCommand.Parameters.Add("@explotacion", SqlDbType.Bit, 1, "explotacion");
                    adapter.InsertCommand.Parameters.Add("@tipoTarea", SqlDbType.NVarChar, 50, "TipoTarea");

                    adapter.Fill(table);

                    xml.Load(Server.MapPath("../App_Data/" + dlAsignaturas.SelectedValue + ".xml"));

                    XmlNodeList listaTareasXml = xml.GetElementsByTagName("tarea");

                    for (int i = 0; i < listaTareasXml.Count; i++)
                    {
                        String str = "Codigo = '" + listaTareasXml[i].Attributes[0].InnerText + "'";
                        DataRow[] foundRows = table.Select(str);
                        if (foundRows.Length > 0)
                        {//Ya existe el registro
                            lblFeedback.Text = "Ya existe el registro";
                            return;
                        }
                    }
                    for (int i = 0; i < listaTareasXml.Count; i++)
                    {
                        table.Rows.Add(
                                listaTareasXml[i].Attributes[0].InnerText,
                                listaTareasXml[i].ChildNodes[0].InnerText,
                                dlAsignaturas.SelectedValue,
                                listaTareasXml[i].ChildNodes[1].InnerText,
                                listaTareasXml[i].ChildNodes[2].InnerText,
                                listaTareasXml[i].ChildNodes[3].InnerText
                            );
                    }

                    adapter.Update(table);
                    lblFeedback.Text = "Tareas insertadas en la bd";
                }
                catch (Exception ex)
                {
                    lblFeedback.Text = "Vaya, ha ocurrido algún error";
                }
            }
            else
            {
                lblFeedback.Text = "Error en el archivo";
            }
        }

        private void cargarTabla()
        {
            try
            {
                lblFeedback.Text = "";

                if (File.Exists(Server.MapPath("../App_Data/" + dlAsignaturas.SelectedValue + ".xml")))
                {
                    xmlTareas.DocumentSource = Server.MapPath("../App_Data/" + dlAsignaturas.SelectedValue + ".xml");
                    xmlTareas.TransformSource = Server.MapPath("../App_Data/VerTablaTareas.xsl");
                }
                else
                {
                    lblFeedback.Text = "Error al cargar el archivo.";
                }

            }
            catch (Exception ex)
            {
                lblFeedback.Text = "Vaya, ha ocurrido un error.";
            }

        }
        protected void dlAsignaturas_SelectedIndexChanged1(object sender, EventArgs e)
        {
            cargarTabla();
        }
    }
}