using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;


namespace lab_2_1
{
	internal class Selects : Connection
	{


		public Selects(SqlConnection conn) : base(conn)
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



		public void GetTables()
		{
			Connecting();
			DataTable table = base.Conection.GetSchema("Tables");
			foreach (DataRow dataRow in table.Rows)
			{
				Console.WriteLine("  {0}", dataRow[2]);
			}
			CloseConnection();
		}

		public void SelectAllItems(string table_name)
		{
			if (table_name == null)
			{
				table_name = "FACULTY";
			}
			Connecting();
			try
			{
				SqlCommand cm = new SqlCommand("select * from " + table_name, base.Conection);
				SqlDataReader sdr = cm.ExecuteReader();
				if (sdr.HasRows) // если есть данные
				{
					// выводим названия столбцов
					string columnName1 = sdr.GetName(0);
					string columnName2 = sdr.GetName(1);
					string columnName3 = sdr.GetName(2);
					string columnName4 = sdr.GetName(3);
					string columnName5 = sdr.GetName(4);

					Console.WriteLine($"{columnName1}\t{columnName2}\t{columnName3}\t{columnName4}\t{columnName5}");

					while (sdr.Read()) // построчно считываем данные
					{
						object FacPK = sdr.GetValue(0);
						object name = sdr.GetValue(1);
						object DeanFK = sdr.GetValue(2);
						object Building = sdr.GetValue(3);
						object Fund = sdr.GetValue(4);

						Console.WriteLine($"{FacPK} \t{name} \t{DeanFK} \t{Building} \t{Fund}");
					}
				}


			}
			catch (Exception e)
			{
				Console.WriteLine("OOPs, something went wrong." + e);
			}
			finally
			{
				CloseConnection();
			}
		}
	}
}