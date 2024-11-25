using Shared.Models.Products;
using Shared.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.DataAccess.Abstract
{
	public interface ISystemDal
	{
		Task<AddString> AddStringAsync(AddString model);
		Task<AddStringLocale> AddStringLocaleAsync(AddStringLocale model);
		Task<List<StringGroup>> GetAllStringGroupCurrentPage();
		Task<List<Strings>> GetAllStringListCurrentPage(int groupId);
		Task<List<Strings>> GetAllStrings();
		Task<StringGroup> GetAllStringsByStringGroup(string groupName);
		Task<Strings> GetStringById(int id);
		Task UpdateString(UpdateString model);
		Task UpdateStringLocale(UpdateStringLocale model);
		Task Delete(int id);
	}
}
