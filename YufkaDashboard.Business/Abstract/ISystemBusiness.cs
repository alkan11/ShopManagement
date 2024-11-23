using Shared.Models.Products;
using Shared.Models.System;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.Business.Abstract
{
	public interface ISystemBusiness
	{
		Task<Response<AddString>> AddStringAsync(AddString model);
		Task<Response<AddStringLocale>> AddStringLocaleAsync(AddStringLocale model);
		Task<Response<List<Strings>>> GetAllStrings();
		Task<Response<List<Strings>>> GetAllStringsCurrentPage();
		Task<Response<List<Strings>>> GetAllGroupDetailList(string groupName);
		Task<Response<NoContent>> Delete(int id);
	}
}
