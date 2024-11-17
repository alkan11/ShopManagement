using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.DataAccess.Abstract
{
	public interface IProductDal
	{
		Task<Products> AddProduct(Products model);
		Task<Products> UpdateProduct(Products model);
		Task Delete(int id);
	}
}
