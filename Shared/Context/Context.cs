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
			_connectionString = "Data Source=(localdb)\\YufkaDB;Initial Catalog=YufkaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
			//_connectionString = "Data Source=ALKAN;Initial Catalog=YufkaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
		}

		public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
	}
}
