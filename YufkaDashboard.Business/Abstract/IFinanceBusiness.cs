using Shared.Models.Finance;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.Business.Abstract
{
	public interface IFinanceBusiness
	{
		public Task<Response<List<SummerGoes>>> GetDailySummerGoes();
		public Task<Response<List<WriteIncome>>> GetDailyWriteIncome();
		public Task<Response<SummerGoes>> AddSummerGoes(SummerGoes model);
		public Task<Response<WriteIncome>> AddWriteIncome(WriteIncome model);
		public Task<Response<EndDay>> AddEndDay(EndDay model);
		public Task<Response<List<EndDay>>> GetAllEndDays();
		public Task<Response<List<WriteIncome>>> GetAllWriteIncome();
		public Task<Response<List<SummerGoes>>> GetAllSummerGoes();
	}
}
