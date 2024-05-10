using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillSaleController : ControllerBase
    {
        public readonly IBillSaleService _BillSaleService;
        public BillSaleController(IBillSaleService BillSaleService)
        {
            _BillSaleService = BillSaleService;
        }

        // GET: api/<BillSaleController>
        [HttpGet]
        public async Task<ActionResult<List<BillSale>>> GetAllBillSale()
        {
            return Ok(await _BillSaleService.GetAll());
        }
        // GET api/<BillSaleController>/5
        [HttpGet("{idBillSale}")]
        public async Task<ActionResult<BillSale>> GetBillSale(int idBillSale)
        {
            var billSale = await _BillSaleService.GetBillSale(idBillSale);
            if (billSale == null)
            {
                return BadRequest("BillSale not found");
            }
            return Ok(billSale);
        }
        // POST: api/BillSale
        [HttpPost]
        public async Task<ActionResult<BillSale>> PostBillSale(int idClient, int idSalesDetails, string notes)
        {
            var BillSaleToPut = await _BillSaleService.CreateBillSale(idClient, idSalesDetails, notes);

            if (BillSaleToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(BillSaleToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/BillSale/5
        [HttpPut("Update/{idBillSale}")]
        public async Task<ActionResult<BillSale>> PutBillSale(int idBillSale, int idClient, int idSalesDetails, string notes)
        {
            var BillSaleToPut = await _BillSaleService.UpdateBillSale(idBillSale, idClient, idSalesDetails, notes);

            if (BillSaleToPut != null)
            {
                return Ok(BillSaleToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/BillSale/5
        [HttpPut("Delete/{idBillSale}")]
        public async Task<ActionResult<BillSale>> DeleteBillSale(int idBillSale)
        {
            var BillSaleToDelete = await _BillSaleService.DeleteBillSale(idBillSale);

            if (BillSaleToDelete != null)
            {
                return Ok(BillSaleToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}
