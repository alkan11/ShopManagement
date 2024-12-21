using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Home
{
	public class Basket
	{
		public int BasketDetailId { get; set; }
		public int Id { get; set; }
		public int BasketId { get; set; }
		public int Status { get; set; }
		public int ProductId { get; set; }
		public string ProductIdName { get; set; }
		public string TypeName { get; set; }
		public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }
	public class RepeaterFormModel
	{
		public List<Basket> Baskets { get; set; } = new List<Basket>();
		public int Id { get; set; }
		public int PaymentTypeId { get; set; }
		public string PaymentTypeIdName { get; set; }
		public decimal TotalPrice { get; set; }
		public int Status { get; set; }
		public DateTime CreatedDate { get; set; }
	}

}
