using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	
	private const string connectionString = "Server=tcp:hads21-19.database.windows.net,1433;Initial Catalog=HADS21-19;Persist Security Info=False;User ID=iberganza004@ikasle.ehu.eus@hads21-19;Password=deLOCOS!!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
	public double obtenerMedia(string codigo)
	{ 

		String sql = "SELECT AVG(HReales) FROM EstudiantesTareas INNER JOIN TareasGenericas ON TareasGenericas.Codigo=EstudiantesTareas.CodTarea WHERE TareasGenericas.CodAsig='" + codigo + "' GROUP BY EstudiantesTareas.email ;";

		SqlConnection connection = new SqlConnection(connectionString);

		SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
		DataTable table = new DataTable();
		adapter.Fill(table);
		double media = 0.0;

		media = Double.Parse(table.Rows[0][0].ToString());

		return media;
	}
}
