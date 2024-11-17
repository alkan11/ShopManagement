using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
	public class Products
	{
		public Products() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public decimal UnitPrice { get; set; }
        public int Status { get; set; }
    }
}
