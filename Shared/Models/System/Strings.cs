using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.System
{
	public class Strings
	{
		public Strings() { }
		public int Id { get; set; }
		public string? StringGroup { get; set; }
		public string? StringDescription { get; set; }
		public int Value1 { get; set; }
		public int Value2 { get; set; }
		public string? Description1 { get; set; }
		public string? Description2 { get; set; }
		public int ParentId { get; set; }
		public int IsActive  { get; set; }
		public int IsSystem { get; set; }
		public int IsSystemValue  { get; set; }
		public string? IsSystemKey { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
