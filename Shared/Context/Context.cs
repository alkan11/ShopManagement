using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Context
{
	public class Context
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;
		public Context(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
	}
}
