using Microsoft.AspNetCore.Http;
using Shared.Models.Products;
using Shared.Models.System;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YufkaDashboard.Business.Abstract;
using YufkaDashboard.DataAccess.Abstract;
using YufkaDashboard.DataAccess.Conrete;

namespace YufkaDashboard.Business.Concrete
{
	public class SystemBusiness : ISystemBusiness
	{
		private readonly ISystemDal _systemDal;

		public SystemBusiness(ISystemDal systemDal)
		{
			_systemDal = systemDal;
		}
		public async Task<Response<AddString>> AddStringAsync(AddString model)
		{
			try
			{
				var result = await _systemDal.AddStringAsync(model);

				return Response<AddString>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<AddString>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<AddStringLocale>> AddStringLocaleAsync(AddStringLocale model)
		{
			try
			{
				var result = await _systemDal.AddStringLocaleAsync(model);

				return Response<AddStringLocale>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<AddStringLocale>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public Task<Response<NoContent>> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Response<List<Strings>>> GetAllStrings()
		{
			throw new NotImplementedException();
		}

		public async Task<Response<List<Strings>>> GetAllStringsCurrentPage()
		{
			try
			{
				var result = await _systemDal.GetAllStringsCurrentPage();

				return Response<List<Strings>>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<List<Strings>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<List<Strings>>> GetAllGroupDetailList(string groupName)
		{
			try
			{
				var result = await _systemDal.GetAllGroupDetailList(groupName);

				return Response<List<Strings>>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<List<Strings>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
	}
}
