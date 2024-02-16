using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace lab_2_1
{
	class Connection
	{

		private SqlConnection _connection;

		public Connection(SqlConnection conn)
		{
			_connection = conn;
		}



		public SqlConnection Conection { get => _connection; set => _connection = value; }

		public void Connecting()
		{

			try
			{
				// Creating Connection  
				_connection.Open();
				Console.WriteLine("Connection Established Successfully");
			}
			catch (Exception e)
			{
				Console.WriteLine("OOPs, something went wrong.\n" + e);
			}

		}

		public void CloseConnection()
		{
			_connection.Close();
		}
	}
}