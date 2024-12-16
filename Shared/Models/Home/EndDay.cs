using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Home
{
	public class EndDay
	{
        public int Id { get; set; }
        public decimal CashTotal { get; set; }
        public decimal CashDiff { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
    }
}
