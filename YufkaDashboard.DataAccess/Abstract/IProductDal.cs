using Shared.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.DataAccess.Abstract
{
    public interface IProductDal
	{
		Task<AddProduct> AddProduct(AddProduct model);
		Task<List<Products>> GetAllProducts();
		Task UpdateProduct(Products model);
		Task<Products> GetProductById(int id);
		Task Delete(int id);
	}
}
