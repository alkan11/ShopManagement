using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Home
{
	public class AddBasketDetail
	{
		public int ProductId  {get;set;}
		public float Amount  {get;set;}
		public decimal Price  {get;set;}
		public int BasketId  {get;set;}
		public int Status  {get;set;}
	}
}
