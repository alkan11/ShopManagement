using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.System
{
	public class StringLocale
	{
		public int Id { get; set; }
		public int StringId { get; set; }
		public string StringDescription { get; set; }
		public int LangId { get; set; }
		public string Description1 { get; set; }
		public string Description2 { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
