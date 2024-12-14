using Shared.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.DataAccess.Abstract
{
	public interface IHomeDal
	{
		public Task<AddBasket> AddBasket(AddBasket model);
		public Task<AddBasketDetail> AddBasketDetail(AddBasketDetail model);
		public Task<List<RepeaterFormModel>> GetAllBaskets();
		public Task<int> GetDailyBasketCount();
	}
}
