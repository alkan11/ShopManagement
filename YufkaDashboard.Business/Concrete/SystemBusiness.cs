﻿using Microsoft.AspNetCore.Http;
using Shared.Models.Products;
using Shared.Models.System;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

		public async Task<Response<NoContent>> Delete(int id)
		{
			try
			{
				await _systemDal.Delete(id);

				return Response<NoContent>.Success(StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<NoContent>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public Task<Response<List<Strings>>> GetAllStrings()
		{
			throw new NotImplementedException();
		}


		public async Task<Response<Strings>> GetStringById(int id)
		{
			try
			{
				var result = await _systemDal.GetStringById(id);

				return Response<Strings>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<Strings>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<NoContent>> UpdateString(UpdateString model)
		{
			try
			{
				await _systemDal.UpdateString(model);

				await _systemDal.UpdateStringLocale(new UpdateStringLocale
				{
					StringId = model.Id,
					StringDescription = model.StringDescription,
					LangId = 0,
					Description1 = model.Description1,
					Description2 = model.Description2,
					CreatedDate = model.CreatedDate
				});

				return Response<NoContent>.Success(StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{
				return Response<NoContent>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<List<StringGroup>>> GetAllStringGroupCurrentPage()
		{
			try
			{
				var result = await _systemDal.GetAllStringGroupCurrentPage();

				return Response<List<StringGroup>>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<List<StringGroup>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<List<Strings>>> GetAllStringListCurrentPage(int groupId)
		{
			try
			{
				var result = await _systemDal.GetAllStringListCurrentPage(groupId);

				return Response<List<Strings>>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<List<Strings>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}



		public async Task<Response<StringGroup>> GetAllStringsByStringGroup(string groupName)
		{
			try
			{
				var result = await _systemDal.GetAllStringsByStringGroup(groupName);

				return Response<StringGroup>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<StringGroup>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<StringGroup>> GetAllStringsByStringGroupActive(string groupName)
		{
			try
			{
				var result = await _systemDal.GetAllStringsByStringGroupActive(groupName);

				return Response<StringGroup>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<StringGroup>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
	}
}
