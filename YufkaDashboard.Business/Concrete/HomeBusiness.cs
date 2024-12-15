using Microsoft.AspNetCore.Http;
using Shared.Models.Home;
using Shared.Models.Products;
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
	public class HomeBusiness : IHomeBusiness
	{
		private readonly IHomeDal _homeDal;

		public HomeBusiness(IHomeDal homeDal)
		{
			_homeDal = homeDal;
		}

		public async Task<Response<AddBasket>> AddBasket(AddBasket model)
		{
			try
			{
				var result = await _homeDal.AddBasket(model);

				return Response<AddBasket>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<AddBasket>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<AddBasketDetail>> AddBasketDetail(AddBasketDetail model)
		{
			try
			{
				var result = await _homeDal.AddBasketDetail(model);

				return Response<AddBasketDetail>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<AddBasketDetail>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<List<RepeaterFormModel>>> GetAllBaskets()
		{
			try
			{
				var result = await _homeDal.GetAllBaskets();

				return Response<List<RepeaterFormModel>>.Success(result, StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<List<RepeaterFormModel>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<int>> GetDailyBasketCount()
		{
			try
			{
				var result = await _homeDal.GetDailyBasketCount();

				return Response<int>.Success(result, StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<int>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<NoContent>> DeleteBasketDetail(int id)
		{
			try
			{
				_homeDal.DeleteBasketDetail(id);

				return Response<NoContent>.Success(StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<NoContent>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<NoContent>> DeleteBasket(int id)
		{
			try
			{
				_homeDal.DeleteBasket(id);

				return Response<NoContent>.Success(StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<NoContent>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<NoContent>> DeleteBasketDetailByBasketId(int basketId)
		{
			try
			{
				_homeDal.DeleteBasketDetailByBasketId(basketId);

				return Response<NoContent>.Success(StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<NoContent>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
	}
}
