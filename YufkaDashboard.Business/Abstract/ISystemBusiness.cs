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
		Task<Response<StringGroup>> GetAllStringsByStringGroup(string groupName);
		Task<Response<StringGroup>> GetAllStringsByStringGroupActive(string groupName);
		Task<Response<List<Strings>>> GetAllStringListCurrentPage(int groupId);
		Task<Response<List<StringGroup>>> GetAllStringGroupCurrentPage();
		Task<Response<Strings>> GetStringById(int id);
		Task<Response<NoContent>> UpdateString(UpdateString model);
		Task<Response<NoContent>> Delete(int id);
	}
}
