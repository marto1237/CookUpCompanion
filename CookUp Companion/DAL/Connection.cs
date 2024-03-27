using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public abstract class Connection
	{
		public string ConnectionString = "Server=mssqlstud.fhict.local;Database=dbi525452_cookup;User Id = dbi525452_cookup; Password=cookup;";

		public SqlConnection connection;
		protected Connection() 
		{
			connection = new SqlConnection(ConnectionString);
		}

	}
}
