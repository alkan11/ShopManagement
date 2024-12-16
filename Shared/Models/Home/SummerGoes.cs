using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Home
{
	public class SummerGoes
	{
        public int Id { get; set; }
        public decimal SummerAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
    }
}
