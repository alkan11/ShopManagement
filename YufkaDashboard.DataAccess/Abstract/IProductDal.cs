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
		Task<Products> UpdateProduct(Products model);
		Task Delete(int id);
	}
}
