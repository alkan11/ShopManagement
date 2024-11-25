using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.System
{
	public class StringGroup
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public int IsActive { get; set; }

		public List<Strings> _strings = new List<Strings>();
	}
}
