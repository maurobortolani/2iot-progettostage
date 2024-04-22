using System.Data.SqlClient;

public class Program
{

	static void Main()
	{
		string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
			"AttachDbFilename=C:\\Users\\bortolanim\\Desktop\\2IOT-ProgettoStage\\2iot-progettostage\\2IOTDB.mdf;" +
			"Integrated Security=True;" +
			"Connect Timeout=30;";

		try
		{
			using(SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				string query = "SELECT * FROM Dati";

				using(SqlCommand cmd = new SqlCommand(query, conn))
				{
					using(SqlDataReader reader = cmd.ExecuteReader())
					{
						while(reader.Read())
						{
							Console.WriteLine(reader.GetInt32(0) + " - " +
								reader.GetDateTime(1).ToString() + " - " +
								reader.GetDecimal(2).ToString() );
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