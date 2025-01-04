using Microsoft.AspNetCore.Http;
using Shared.Models.Finance;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YufkaDashboard.Business.Abstract;
using YufkaDashboard.DataAccess.Abstract;

namespace YufkaDashboard.Business.Concrete
{
	public class FinanceBusiness:IFinanceBusiness
	{
		private readonly IFinanceDal _financeDal;

		public FinanceBusiness(IFinanceDal financeDal)
		{
			_financeDal = financeDal;
		}
		public async Task<Response<SummerGoes>> AddSummerGoes(SummerGoes model)
		{
			try
			{
				var result = await _financeDal.AddSummerGoes(model);

				return Response<SummerGoes>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<SummerGoes>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<SummerGoes>> AddMainCaseSummerGoes(SummerGoes model)
		{
			try
			{
				var result = await _financeDal.AddMainCaseSummerGoes(model);

				return Response<SummerGoes>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<SummerGoes>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<WriteIncome>> AddWriteIncome(WriteIncome model)
		{
			try
			{
				var result = await _financeDal.AddWriteIncome(model);

				return Response<WriteIncome>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<WriteIncome>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<WriteIncome>> AddMainCaseWriteIncome(WriteIncome model)
		{
			try
			{
				var result = await _financeDal.AddMainCaseWriteIncome(model);

				return Response<WriteIncome>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<WriteIncome>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<EndDay>> AddEndDay(EndDay model)
		{
			try
			{
				var result = await _financeDal.AddEndDay(model);

				return Response<EndDay>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<EndDay>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<EndDay>> AddEndMounthBuy(EndDay model)
		{
			try
			{
				var result = await _financeDal.AddEndMounthBuy(model);

				return Response<EndDay>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<EndDay>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<List<SummerGoes>>> GetDailySummerGoes()
		{
			try
			{
				var result = await _financeDal.GetDailySummerGoes();

				return Response<List<SummerGoes>>.Success(result, StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<List<SummerGoes>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<List<WriteIncome>>> GetDailyWriteIncome()
		{
			try
			{
				var result = await _financeDal.GetDailyWriteIncome();

				return Response<List<WriteIncome>>.Success(result, StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<List<WriteIncome>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<List<EndDay>>> GetAllEndDays()
		{
			try
			{
				var result = await _financeDal.GetAllEndDays();

				return Response<List<EndDay>>.Success(result, StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<List<EndDay>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<List<WriteIncome>>> GetAllWriteIncome()
		{
			try
			{
				var result = await _financeDal.GetAllWriteIncome();

				return Response<List<WriteIncome>>.Success(result, StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<List<WriteIncome>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<List<WriteIncome>>> GetAllMounthWriteIncome()
		{
			try
			{
				var result = await _financeDal.GetAllMounthWriteIncome();

				return Response<List<WriteIncome>>.Success(result, StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<List<WriteIncome>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<List<SummerGoes>>> GetAllSummerGoes()
		{
			try
			{
				var result = await _financeDal.GetAllSummerGoes();

				return Response<List<SummerGoes>>.Success(result, StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<List<SummerGoes>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<List<SummerGoes>>> GetAllMounthSummerGoes()
		{
			try
			{
				var result = await _financeDal.GetAllMounthSummerGoes();

				return Response<List<SummerGoes>>.Success(result, StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<List<SummerGoes>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
	}
}
