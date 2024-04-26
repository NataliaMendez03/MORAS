using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HClinicalV2._0.Controllers
{
    [Route("HClinical/[controller]")]
    [ApiController]
    public class IdentificationTypeController : ControllerBase
    {
        private readonly IIdentificationTypeService _IdentificationTypeService;
        public IdentificationTypeController(IIdentificationTypeService IdentificationTypeService)
        {
            _IdentificationTypeService = IdentificationTypeService;
        }


        // GET: api/<IdentificationTypeController>
        [HttpGet]
        public async Task<ActionResult<List<IdentificationType>>> GetAllIdentificationType()
        {
            return Ok(await _IdentificationTypeService.GetAll());
        }

        // GET api/<IdentificationTypeController>/5
        [HttpGet("{idIdentificationType}")]
        public async Task<ActionResult<IdentificationType>> GetIdentificationType(int idIdentificationType)
        {
            var IdentificationType = await _IdentificationTypeService.GetIdentificationType(idIdentificationType);
            if (IdentificationType == null)
            {
                return BadRequest("IdentificationType not found :(");
            }
            return Ok(IdentificationType);
        }

        // IdentificationType: api/IdentificationType
        [HttpPost]
        public async Task<ActionResult<IdentificationType>> IdentificationTypeIdentificationType(string nameIdentificationType)
        {
            var IdentificationTypeToPut = await _IdentificationTypeService.CreateIdentificationType(nameIdentificationType);

            if (IdentificationTypeToPut != null)
            {
                return Ok(IdentificationTypeToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database :(");
            }


        }

        // PUT: api/IdentificationType/5
        [HttpPut("Update/{idIdentificationType}")]
        public async Task<ActionResult<IdentificationType>> PutIdentificationType(int idIdentificationType, string nameIdentificationType)
        {
            var IdentificationTypeToPut = await _IdentificationTypeService.UpdateIdentificationType(idIdentificationType, nameIdentificationType);

            if (IdentificationTypeToPut != null)
            {
                return Ok(IdentificationTypeToPut);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }

        }

        // Delete: api/IdentificationType/5
        [HttpPut("Delete/{idIdentificationType}")]
        public async Task<ActionResult<IdentificationType>> DeleteIdentificationType(int idIdentificationType)
        {

            var IdentificationTypeToDelete = await _IdentificationTypeService.DeleteIdentificationType(idIdentificationType);

            if (IdentificationTypeToDelete != null)
            {
                return Ok(IdentificationTypeToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }

}