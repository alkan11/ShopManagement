﻿using Shared.Models.Finance;
using Shared.Models.Home;
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
		public Task<Response<SummerGoes>> AddMainCaseSummerGoes(SummerGoes model);
		public Task<Response<WriteIncome>> AddWriteIncome(WriteIncome model);
		public Task<Response<WriteIncome>> AddMainCaseWriteIncome(WriteIncome model);
		public Task<Response<EndDay>> AddEndDay(EndDay model);
		public Task<Response<EndDay>> AddEndMounthBuy(EndDay model);
		public Task<Response<List<EndDay>>> GetAllEndDays();
		public Task<Response<List<WriteIncome>>> GetAllWriteIncome();
		public Task<Response<List<WriteIncome>>> GetAllMounthWriteIncome();
		public Task<Response<List<SummerGoes>>> GetAllSummerGoes();
		public Task<Response<List<SummerGoes>>> GetAllMounthSummerGoes();
		public Task<Response<List<ChartDailyEndDay>>> ChartDailyEndDay();
	}
}
