using Dapper;
using Microsoft.Data.SqlClient;
using Quartz;
using Shared.Context;

namespace YufkaDashboard.Web.Quartz
{
    public class BackgroundJob : IJob
    {
        private readonly Context _context;

        public BackgroundJob(Context context)
        {
            _context = context;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var connection = new SqlConnection(_context.CreateConnection().ToString()))
            {
                await connection.OpenAsync();
                await connection.QueryAsync("Exec pGetAutomaticEndDay");
                await connection.CloseAsync();

            }
        }
    }
}
