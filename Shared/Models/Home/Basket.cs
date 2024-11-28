using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Home
{
	public class Basket
	{
        public decimal Price { get; set; }
        public float Amount { get; set; }
        public int ProductId { get; set; }
    }
	public class RepeaterFormModel
	{
		public List<Basket> Baskets { get; set; }
	}
}
