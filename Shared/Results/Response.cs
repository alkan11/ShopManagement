using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Results
{
	public class Response<T>
	{
		public T? Data { get; set; }

		public int StatusCode { get; set; }

		public bool IsSuccessful { get; set; }

		public string? Message { get; set; }


		public static Response<T> Success(T data, int statusCode)
		{
			return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
		}

		public static Response<T> Success(T data, string message, int statusCode)
		{
			return new Response<T> { Data = data, Message = message, StatusCode = statusCode, IsSuccessful = true };
		}

		public static Response<T> Success(int statusCode)
		{
			return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccessful = true };
		}

		public static Response<T> Fail(string message, int statusCode)
		{
			return new Response<T> { Message = message, StatusCode = statusCode, IsSuccessful = false };
		}
	}
}
