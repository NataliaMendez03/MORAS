using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        public readonly IPurchaseService _PurchaseService;
        public PurchaseController(IPurchaseService PurchaseService)
        {
            _PurchaseService = PurchaseService;
        }

        // GET: api/<PurchaseController>
        [HttpGet]
        public async Task<ActionResult<List<Purchase>>> GetAllPurchase()
        {
            return Ok(await _PurchaseService.GetAll());
        }
        // GET api/<PurchaseController>/5
        [HttpGet("{idPurchase}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int idPurchase)
        {
            var purchase = await _PurchaseService.GetPurchase(idPurchase);
            if (purchase == null)
            {
                return BadRequest("Purchase not found");
            }
            return Ok(purchase);
        }
        // POST: api/BillSale
        [HttpPost("{IdPurchase}")]
        public async Task<ActionResult<Purchase>> PostPurchase(int idProviders, DateTime dateproviders, int IdPurchaseDetail)
        {
            var PurchaseToPut = _PurchaseService.CreatePurchase(idProviders, dateproviders, IdPurchaseDetail);

            if (PurchaseToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(PurchaseToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/Purchase/5
        [HttpPut("Update/{idPurchase}")]
        public async Task<ActionResult<Purchase>> PutPurchase(int idPurchase, int idProviders, DateTime datePurchase, int idPurchaseDetail)
        {
            var PurchaseToPut = _PurchaseService.UpdatePurchase(idPurchase, idProviders, datePurchase, idPurchaseDetail);

            if (PurchaseToPut != null)
            {
                return Ok(PurchaseToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Purchase/5
        [HttpPut("Delete/{idPurchase}")]
        public async Task<ActionResult<Purchase>> DeletePurchase(int idPurchase)
        {
            var PurchaseToDelete = _PurchaseService.DeletePurchase(idPurchase);

            if (PurchaseToDelete != null)
            {
                return Ok(PurchaseToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}