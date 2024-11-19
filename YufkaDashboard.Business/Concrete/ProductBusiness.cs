using Microsoft.AspNetCore.Http;
using Shared.Models.Products;
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
	public class ProductBusiness : IProductBusiness
	{
		private readonly IProductDal _productDal;

		public ProductBusiness(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public async Task<Response<AddProduct>> AddProduct(AddProduct model)
		{
			try
			{
				var result = await _productDal.AddProduct(model);

				return Response<AddProduct>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<AddProduct>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public Task<Response<NoContent>> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Response<List<Products>>> GetAllProducts()
		{
			try
			{
				var result = await _productDal.GetAllProducts();

				return Response<List<Products>>.Success(result,StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<List<Products>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
			

		}
	}
}
