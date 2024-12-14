using Shared.Models.Home;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.Business.Abstract
{
	public interface IHomeBusiness
	{
		public Task<Response<AddBasket>> AddBasket(AddBasket model);
		public Task<Response<AddBasketDetail>> AddBasketDetail(AddBasketDetail model);
		public Task<Response<List<RepeaterFormModel>>> GetAllBaskets();
		public Task<Response<int>> GetDailyBasketCount();
	}
}
