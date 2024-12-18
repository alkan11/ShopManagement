
using Shared.Models.Auth;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.Business.Abstract
{
	public interface IAuthBussiness
	{
		public Task<Response<List<Users>>> GetAllUsers();
	}
}
