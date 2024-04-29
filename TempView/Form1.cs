using LiveCharts.Wpf;
using LiveCharts;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Media;

namespace TempView
{
	public partial class Form1 : Form
	{
		public class Dato
		{
			public int Id { get; set; }
			public DateTime DateTime { get; set; }
			public string Temperatura { get; set; }
			public double NumTemp { get; set; }
		}

		public static List<Dato> dati;

		public Form1()
		{
			InitializeComponent();
			timer1.Enabled = true;


			
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			readDB();
			List<double> temperature = new List<double>();
			textBoxDebug.Text = string.Empty;
			cartesianChart1.Series.Clear();
			foreach (var dato in dati)
			{
				textBoxDebug.Text += dato.Temperatura.Trim() + " | ";
				temperature.Add(Convert.ToDouble(dato.Temperatura));
			}

			cartesianChart1.Series = new SeriesCollection
			{
				new LineSeries
				{
					Title = "Series 1",
					Values = new ChartValues<double>()
				}
			};

			foreach (var t in temperature)
			{
				cartesianChart1.Series[0].Values.Add(t);
			}
			

		}


		public static void readDB()
		{
			string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
				"AttachDbFilename=C:\\Users\\bortolanim\\Desktop\\2IOT-ProgettoStage\\2iot-progettostage\\2IOTDB.mdf;" +
				"Integrated Security=True;" +
				"Connect Timeout=30;";

			dati = new List<Dato>();
			
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
								dato.Temperatura = reader.GetString(2);
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
					
		}
	}
}
