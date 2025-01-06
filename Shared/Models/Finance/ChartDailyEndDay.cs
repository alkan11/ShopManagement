using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Finance
{
	public class ChartDailyEndDay
	{
		public DateTime Date { get; set; }
		public string FormattedDate { get; set; }
		public decimal TotalValue { get; set; }
	}
}
