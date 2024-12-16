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
		public Task<Response<NoContent>> DeleteBasketDetail(int id);
		public Task<Response<NoContent>> DeleteBasket(int id);
		public Task<Response<NoContent>> DeleteBasketDetailByBasketId(int basketId);
		public Task<Response<SummerGoes>> AddSummerGoes(SummerGoes model);
		public Task<Response<WriteIncome>> AddWriteIncome(WriteIncome model);
		public Task<Response<EndDay>> AddEndDay(EndDay model);
	}
}
