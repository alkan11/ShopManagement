﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Home
{
	public class Basket
	{
		public int ProductId { get; set; }
		public decimal Price { get; set; }

        public float Amount { get; set; }
    }
	public class RepeaterFormModel
	{
		public List<Basket> Baskets { get; set; }
		public int PaymentTypeId { get; set; }
		public decimal TotalPrice { get; set; }
		public int Status { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
