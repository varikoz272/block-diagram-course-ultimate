using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Block.manage.SQL
{
	public class SqlTableManager
	{
		private SqlConnection connection;
		public SqlTableManager(SqlConnection connection)
		{
			this.connection = connection;
			connection.Open();
		}

		public DataTable GetTable(string tableName)
		{
			string query = "SELECT * FROM " + tableName;
			SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
			DataTable table = new DataTable();
			dataAdapter.Fill(table);

			return table;
		}

		public void CloseConnection()
		{
			connection.Close();
		}

		public void PrintTable(DataTable table)
		{
			foreach(DataRow row in table.Rows)
			{
				foreach(DataColumn column in table.Columns)
				{
					Console.Write(row[column] + "(" +  row[column].GetType() + ") | ");
				}
				Console.WriteLine("");
			}
		}
	}

}
