using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;
using static Azure.Core.HttpHeader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseDetailController : ControllerBase
    {
        private readonly IPurchaseDetailService _PurchaseDetailService;
        public PurchaseDetailController(IPurchaseDetailService PurchaseDetailService)
        {
            _PurchaseDetailService = PurchaseDetailService;
        }


        // GET: api/<PurchaseDetailController>
        [HttpGet]
        public async Task<ActionResult<List<PurchaseDetail>>> GetAllPurchaseDetail()
        {
            return Ok(await _PurchaseDetailService.GetAll());
        }

        // GET api/<PurchaseDetailController>/5
        [HttpGet("{idPurchaseDetail}")]
        public async Task<ActionResult<PurchaseDetail>> GetPurchaseDetail(int idPurchaseDetail)
        {
            var PurchaseDetail = await _PurchaseDetailService.GetPurchaseDetail(idPurchaseDetail);
            if (PurchaseDetail == null)
            {
                return BadRequest("PurchaseDetail not found :(");
            }
            return Ok(PurchaseDetail);
        }

        // PurchaseDetail: api/PurchaseDetail
        [HttpPost]
        public async Task<ActionResult<PurchaseDetail>> PurchaseDetailPurchaseDetail(int idSupplies, int quantity, string purchasePrice, string notes)
        {
            var PurchaseDetailToPut = await _PurchaseDetailService.CreatePurchaseDetail(idSupplies, quantity, purchasePrice, notes);

            if (PurchaseDetailToPut != null)
            {
                return Ok(PurchaseDetailToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database :(");
            }


        }

        // PUT: api/PurchaseDetail/5
        [HttpPut("Update/{idPurchaseDetail}")]
        public async Task<ActionResult<PurchaseDetail>> PutPurchaseDetail(int idPurchaseDetail, int idSupplies, int quantity, string purchasePrice, string notes)
        {
            var PurchaseDetailToPut = await _PurchaseDetailService.UpdatePurchaseDetail(idPurchaseDetail, idSupplies, quantity, purchasePrice, notes);

            if (PurchaseDetailToPut != null)
            {
                return Ok(PurchaseDetailToPut);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }

        }

        // Delete: api/PurchaseDetail/5
        [HttpDelete("Delete/{idPurchaseDetail}")]
        public async Task<ActionResult<PurchaseDetail>> DeletePurchaseDetail(int idPurchaseDetail)
        {

            var PurchaseDetailToDelete = await _PurchaseDetailService.DeletePurchaseDetail(idPurchaseDetail);

            if (PurchaseDetailToDelete != null)
            {
                return Ok(PurchaseDetailToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }

}