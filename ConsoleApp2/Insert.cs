using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace lab_2_1
{
	internal class Insert : Connection
	{
		public Insert(SqlConnection conn) : base(conn)
		{

		}



		private new void Connecting()
		{

			base.Connecting();

		}

		public new void CloseConnection()
		{
			base.CloseConnection();
		}

		public void InsertSubject(string sbj)
		{
			string sqlExpression = "INSERT INTO [SUBJECT] (Name) VALUES ('"+sbj+"')";
			Connecting();
			try
			{
				SqlCommand command = new SqlCommand(sqlExpression, Conection);
				Console.WriteLine("Inserting completed");
			}
			catch (Exception e)
			{
				Console.WriteLine("OOPs, something went wrong.\n" + e);
			}
			CloseConnection();

		}
	}

}