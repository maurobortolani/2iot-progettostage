using Microsoft.SqlServer.Server;
using System.Data.SqlClient;

public class Program
{
	public class Dato
	{
		public int Id { get; set; }
		public DateTime DateTime { get; set; }
		public string Temperatura { get; set; }
	}

	static void Main()
	{

		Dato dato = new Dato()
		{
			Temperatura = (15.25).ToString()
		};



		scriviDato(dato);
		
	}	

	public static void scriviDato(Dato x)
	{
		string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
			"AttachDbFilename=C:\\Users\\bortolanim\\Desktop\\2IOT-ProgettoStage\\2iot-progettostage\\2IOTDB.mdf;" +
			"Integrated Security=True;" +
			"Connect Timeout=30;";

		try
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				string queryInsert = $"INSERT INTO Dati (Message) VALUES ('{x.Temperatura}')";

				using (SqlCommand cmd = new SqlCommand(queryInsert, conn))
				{
					cmd.ExecuteNonQuery();
				}

				conn.Close();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}

	public static void readDB()
	{
		string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
			"AttachDbFilename=C:\\Users\\bortolanim\\Desktop\\2IOT-ProgettoStage\\2iot-progettostage\\2IOTDB.mdf;" +
			"Integrated Security=True;" +
			"Connect Timeout=30;";

		List<Dato> dati = new List<Dato>();

		try
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				string query = "SELECT * FROM Dati";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Dato dato = new Dato();
							dato.Id = reader.GetInt32(0);
							dato.DateTime = reader.GetDateTime(1);
							//dato.Temperatura = reader.GetDecimal(2);
							dati.Add(dato);
						}
					}
				}

				conn.Close();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}


		foreach (Dato dato in dati)
		{
			Console.WriteLine($"{dato.Id} - {dato.DateTime} - {dato.Temperatura}°C");
		}
	}
}