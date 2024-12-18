
using Microsoft.AspNetCore.Http;
using Shared.Models.Auth;
using Shared.Models.Documents;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YufkaDashboard.Business.Abstract;
using YufkaDashboard.DataAccess.Abstract;
using YufkaDashboard.DataAccess.Conrete;

namespace YufkaDashboard.Business.Concrete
{
	public class AuthBussiness : IAuthBussiness
	{
		private IAuthDal authDal;

		public AuthBussiness(IAuthDal authDal)
		{
			this.authDal = authDal;
		}

		public async Task<Response<List<Users>>> GetAllUsers()
		{
			try
			{
				var result = await authDal.GetAllUsers();

				return Response<List<Users>>.Success(result, StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<List<Users>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
	}
}
