using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesDetailsController : ControllerBase
    {
        public readonly ISalesDetailsService _salesDetailsService;
        public SalesDetailsController(ISalesDetailsService salesDetailsService)
        {
            _salesDetailsService = salesDetailsService;
        }
        // GET: api/<SalesDetailsController>
        [HttpGet]
        public async Task<ActionResult<List<SalesDetails>>> GetAllSalesDetails()
        {
            return Ok(await _salesDetailsService.GetAll());
        }
        // GET api/<SalesDetailsController>/5
        [HttpGet("{idSalesDetails}")]
        public async Task<ActionResult<SalesDetails>> GetSalesDetails(int idSalesDetails)
        {
            var tracking = await _salesDetailsService.GetSalesDetails(idSalesDetails);
            if (tracking == null)
            {
                return BadRequest("SalesDetails not found");
            }
            return Ok(tracking);
        }
        // POST: api/SalesDetails
        [HttpPost]
        public async Task<ActionResult<SalesDetails>> PostSalesDetails(string amount, string salePrice)
        {
            var SalesDetailsToPut = _salesDetailsService.CreateSalesDetails(amount, salePrice);

            if (SalesDetailsToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(SalesDetailsToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }


        }
        // PUT: api/SalesDetails/5
        [HttpPut("Update/{idSalesDetails, amount}")]
        public async Task<ActionResult<SalesDetails>> PutSalesDetails(int idSalesDetails, string amount, string salePrice)
        {
            var SalesDetailsToPut = _salesDetailsService.UpdateSalesDetails(idSalesDetails, amount, salePrice);

            if (SalesDetailsToPut != null)
            {
                return Ok(SalesDetailsToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/SalesDetails/5
        [HttpPut("Delete/{idSalesDetails}")]
        public async Task<ActionResult<SalesDetails>> DeleteSalesDetails(int idSalesDetails)
        {
            var SalesDetailsToDelete = _salesDetailsService.DeleteSalesDetails(idSalesDetails);

            if (SalesDetailsToDelete != null)
            {
                return Ok(SalesDetailsToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }

}
