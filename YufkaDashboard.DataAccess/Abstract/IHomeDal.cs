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
		public Task<List<RepeaterFormModel>> GetAllSalesRecords();
		public Task<int> GetDailyBasketCount();
		public Task DeleteBasketDetail(int id);
		public Task DeleteBasket(int id);
		public Task DeleteBasketDetailByBasketId(int basketId);
		
		public Task<List<RepeaterFormModel>> GetDailyBaskets();
		

		public Task<Basket> FindBasketDetail(int id);
		public Task<RepeaterFormModel> FindBasket(int id);

		public Task NewBasketTotalPrice(int id, decimal totalPrice);
		public Task<List<ChartDailyYufkaCounts>> ChartDailyYufkaCounts();
		public Task<List<ChartDailyMantiKG>> ChartDailyMantiKG();
	}
}
