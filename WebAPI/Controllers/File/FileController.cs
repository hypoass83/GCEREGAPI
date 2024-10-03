using Microsoft.AspNetCore.Mvc;
using Domain.InterfacesServices.File;
using Domain.InterfacesServices.Security;
using Domain.InterfacesServices.Parameters;
using Domain.Models.Parameters;
using Domain.DTO;
using Microsoft.AspNetCore.Http.HttpResults;


namespace WebAPI.Controllers.File
{

    [ApiController]
    [Route("api/files/")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<int> UploadFile(IFormFile file)
        {
            var res = _fileService.UploadFile(file);
            return Ok(res);
        }
    }
}