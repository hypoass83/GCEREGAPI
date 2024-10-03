// using Application.Domain;
using Domain.DTO;
using Domain.Models;
using Domain.InterfacesStores.Security;
using Microsoft.AspNetCore.Mvc;
using Domain.InterfacesServices.Security;
using Domain.Models.Security;
using Domain.Models.Localisation;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/loclalisation/")]
    [Authorize]
    public class LocalisationController : ControllerBase
    {
        ICountryService _countryService;
        ISubDivisionService _SubDivisionService;

        IDivisionService _DivisionService;
        IRegionService _regionService;

        public LocalisationController(ICountryService countryService, ISubDivisionService SubDivisionService, IDivisionService DivisionService, IRegionService regionService)
        {
            _countryService = countryService;
            _SubDivisionService = SubDivisionService;
            _DivisionService = DivisionService;
            _regionService = regionService;

        }

        [HttpPost("/create-country")]
        public CountryModel? CreateCountry(CountryModel CountryModel)
        {
            return _countryService.CreateCountry(CountryModel);
        }


        [HttpGet("get-country/{CountryId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CountryModel> GetCountryById(int CountryId)
        {
            var Country = _countryService.GetCountryById(CountryId);
            if (Country == null)
            {
                return NotFound();
            }

            return Ok(Country);
        }

        [HttpGet("get-all-country")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CountryModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CountryModel>> GetAllCountrys()
        {
            var Countrys = _countryService.GetAllCountrys();
            if (Countrys == null)
            {
                return NotFound();
            }

            return Ok(Countrys);
        }

        [HttpPut("update-country")]
        public CountryModel? UpdateCountry(CountryModel CountryModel)
        {
           return _countryService.UpdateCountry(CountryModel);
                      
        }

        [HttpDelete("delete-country")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteCountry(int CountryId)
        {
            var result = _countryService.DeleteCountry(CountryId);

            if (!result)
            {
                return NotFound(); // This will return a 404 status code.
            }

            return Ok(true); // This will return a 200 status code with a boolean value.
        }

        [HttpPost("/create-region")]
        public RegionModel? CreateRegion(RegionModel RegionModel)
        {
            return _regionService.CreateRegion(RegionModel);
        }


        [HttpGet("get-region/{RegionId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RegionModel> GetRegionById(int RegionId)
        {
            var Region = _regionService.GetRegionById(RegionId);
            if (Region == null)
            {
                return NotFound();
            }

            return Ok(Region);
        }

        [HttpGet("get-all-region")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RegionModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<RegionModel>> GetAllRegions()
        {
            var Regions = _regionService.GetAllRegions();
            if (Regions == null)
            {
                return NotFound();
            }

            return Ok(Regions);
        }

        [HttpPut("update-region")]
        public RegionModel? UpdateRegion(RegionModel RegionModel)
        {
            return _regionService.UpdateRegion(RegionModel);            
        }

        [HttpDelete("delete-region")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteRegion(int RegionId)
        {
            var result = _regionService.DeleteRegion(RegionId);

            if (!result)
            {
                return NotFound(); // This will return a 404 status code.
            }

            return Ok(true); // This will return a 200 status code with a boolean value.
        }


        [HttpPost("/create-Division")]
        public DivisionModel? CreateDivision(DivisionModel DivisionModel)
        {
            return _DivisionService.CreateDivision(DivisionModel);
        }


        [HttpGet("get-Division/{DivisionId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DivisionModel> GetDivisionById(int DivisionId)
        {
            var Division = _DivisionService.GetDivisionById(DivisionId);
            if (Division == null)
            {
                return NotFound();
            }

            return Ok(Division);
        }

        [HttpGet("get-all-Division")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DivisionModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<DivisionModel>> GetAllDivisions()
        {
            var Divisions = _DivisionService.GetAllDivisions();
            if (Divisions == null)
            {
                return NotFound();
            }

            return Ok(Divisions);
        }

        [HttpPut("update-Division")]
        public DivisionModel? UpdateDivision(DivisionModel DivisionModel)
        {
            return _DivisionService.UpdateDivision(DivisionModel);
        }

        [HttpDelete("delete-Division")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteDivision(int DivisionId)
        {
            var result = _DivisionService.DeleteDivision(DivisionId);

            if (!result)
            {
                return NotFound(); // This will return a 404 status code.
            }

            return Ok(true); // This will return a 200 status code with a boolean value.
        }


        [HttpPost("/create-SubDivision")]
        public SubDivisionModel? CreateSubDivision(SubDivisionModel SubDivisionModel)
        {
            return _SubDivisionService.CreateSubDivision(SubDivisionModel);
        }


        [HttpGet("get-SubDivision/{SubDivisionId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SubDivisionModel> GetSubDivisionById(int SubDivisionId)
        {
            var SubDivision = _SubDivisionService.GetSubDivisionById(SubDivisionId);
            if (SubDivision == null)
            {
                return NotFound();
            }

            return Ok(SubDivision);
        }

        [HttpGet("get-all-SubDivision")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SubDivisionModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<SubDivisionModel>> GetAllSubDivisions()
        {
            var SubDivisions = _SubDivisionService.GetAllSubDivisions();
            if (SubDivisions == null)
            {
                return NotFound();
            }

            return Ok(SubDivisions);
        }

        [HttpPut("update-SubDivision")]
        public SubDivisionModel? UpdateSubDivision(SubDivisionModel SubDivisionModel)
        {
            return  _SubDivisionService.UpdateSubDivision(SubDivisionModel);
        }

        [HttpDelete("delete-SubDivision")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteSubDivision(int SubDivisionId)
        {
            var result = _SubDivisionService.DeleteSubDivision(SubDivisionId);

            if (!result)
            {
                return NotFound(); // This will return a 404 status code.
            }

            return Ok(true); // This will return a 200 status code with a boolean value.
        }



    }
}