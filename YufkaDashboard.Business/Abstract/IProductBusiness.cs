using Shared.Models.Products;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.Business.Abstract
{
	public interface IProductBusiness
	{
		Task<Response<AddProduct>> AddProduct(AddProduct model);
		Task<Response<List<Products>>> GetAllProducts();
		Task<Response<NoContent>> Delete(int id);
	}
}
