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

		public async Task<Response<Files>> AddFile(Files model)
		{
			try
			{
				var result = await _documentDal.AddFile(model);

				return Response<Files>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<Files>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
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

		public async Task<Response<Folder>> FindFolder(int id)
		{
			try
			{
				var result = await _documentDal.FindFolder(id);

				return Response<Folder>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<Folder>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public async Task<Response<Files>> FindFile(int id)
		{
			try
			{
				var result = await _documentDal.FindFile(id);

				return Response<Files>.Success(result, StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{

				return Response<Files>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}

		public async Task<Response<List<Files>>> GetAllFilesByFolderId(int folderId)
		{
			try
			{
				var result = await _documentDal.GetAllFilesByFolderId(folderId);

				return Response<List<Files>>.Success(result, StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<List<Files>>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
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

		public  async Task<Response<NoContent>> DeleteFile(int id)
		{
			try
			{
				  _documentDal.DeleteFile(id);

				return Response<NoContent>.Success(StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<NoContent>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
		public  async Task<Response<NoContent>> DeleteFolder(int id)
		{
			try
			{
				  _documentDal.DeleteFolder(id);

				return Response<NoContent>.Success(StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{

				return Response<NoContent>.Fail("TheOperationCouldNotBePerformed", StatusCodes.Status500InternalServerError);
			}
		}
	}
}
