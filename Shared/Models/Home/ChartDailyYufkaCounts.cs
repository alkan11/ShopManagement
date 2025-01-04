using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Home
{
	public class ChartDailyYufkaCounts
	{
		public DateTime Date { get; set; }
		public string FormattedDate { get; set; }
		public int Amounts { get; set; }
	}
}
