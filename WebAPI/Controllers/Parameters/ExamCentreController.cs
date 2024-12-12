// using Application.Domain;
using Domain.DTO;
using Domain.Models;
using Domain.InterfacesStores.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Models.Parameters;
using Domain.InterfacesServices.Parameters;

namespace WebAPI.Controllers.Parameters
{
    [ApiController]
    [Route("api/ExamCentres/")]
    [Authorize]
    public class ExamCentreController : ControllerBase
    {
        IExamCentreService _ExamCentreService;

        public ExamCentreController(IExamCentreService ExamCentreService)
        {
            _ExamCentreService = ExamCentreService;
        }

        [HttpPost]
        public ExamCentreModel? CreateExamCentre(ExamCentreModel ExamCentreModel)
        {
            return _ExamCentreService.CreateExamCentre(ExamCentreModel);
        }


        [HttpGet("{ExamCentreId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ExamCentreModel> GetExamCentreById(int ExamCentreId)
        {
            var ExamCentre = _ExamCentreService.GetExamCentreById(ExamCentreId);
            if (ExamCentre == null)
            {
                return NotFound();
            }

            return Ok(ExamCentre);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ExamCentreModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ExamCentreModel>> GetAllExamCentres()
        {
            var ExamCentres = _ExamCentreService.GetAllExamCentres();
            if (ExamCentres == null)
            {
                return NotFound();
            }

            return Ok(ExamCentres);
        }

        [HttpPut]
        public ExamCentreModel? UpdateExamCentre(ExamCentreModel ExamCentreModel)
        {
            return _ExamCentreService.UpdateExamCentre(ExamCentreModel);

        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteExamCentre(int ExamCentreId)
        {
            var result = _ExamCentreService.DeleteExamCentre(ExamCentreId);

            if (!result)
            {
                return NotFound(); // This will return a 404 status code.
            }

            return Ok(true); // This will return a 200 status code with a boolean value.
        }

    }
}