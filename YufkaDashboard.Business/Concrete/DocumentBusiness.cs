using Microsoft.AspNetCore.Http;
using Shared.Models.Documents;
using Shared.Models.Home;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YufkaDashboard.Business.Abstract;
using YufkaDashboard.DataAccess.Abstract;
using YufkaDashboard.DataAccess.Conrete;

namespace YufkaDashboard.Business.Concrete
{
	public class DocumentBusiness : IDocumentBusiness
	{
		private readonly IDocumentDal _documentDal;

		public DocumentBusiness(IDocumentDal documentDal)
		{
			_documentDal = documentDal;
		}

		public async Task<Response<AddFolder>> AddFolder(AddFolder model)
		{
			try
			{
				var result = await _documentDal.AddFolder(model);

				return Response<AddFolder>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<AddFolder>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<List<Folder>>> GetAllFolderMain()
		{
			try
			{
				var result = await _documentDal.GetAllFolderMain();

				return Response<List<Folder>>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<List<Folder>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
	}
}
