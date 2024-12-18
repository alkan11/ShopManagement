using Shared.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.DataAccess.Abstract
{
	public interface IAuthDal
	{
		public Task<List<Users>> GetAllUsers();
	}
}
