using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HClinicalV2._0.Controllers
{
    [Route("HClinical/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _EmployeesService;
        public EmployeesController(IEmployeesService EmployeesService)
        {
            _EmployeesService = EmployeesService;
        }


        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ActionResult<List<Employees>>> GetAllEmployees()
        {
            return Ok(await _EmployeesService.GetAll());
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{idEmployees}")]
        public async Task<ActionResult<Employees>> GetEmployees(int idEmployees)
        {
            var Employees = await _EmployeesService.GetEmployees(idEmployees);
            if (Employees == null)
            {
                return BadRequest("Employees not found :(");
            }
            return Ok(Employees);
        }

        // Employees: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employees>> EmployeesEmployees(int idPost, int idPerson)
        {
            var EmployeesToPut = await _EmployeesService.CreateEmployees(idPost, idPerson);

            if (EmployeesToPut != null)
            {
                return Ok(EmployeesToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database :(");
            }


        }

        // PUT: api/Employees/5
        [HttpPut("Update/{idEmployees}")]
        public async Task<ActionResult<Employees>> PutEmployees(int idEmployees, int idPost, int idPerson)
        {
            var EmployeesToPut = await _EmployeesService.UpdateEmployees(idEmployees, idPost, idPerson);

            if (EmployeesToPut != null)
            {
                return Ok(EmployeesToPut);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }

        }

        // Delete: api/Employees/5
        [HttpDelete("Delete/{idEmployees}")]
        public async Task<ActionResult<Employees>> DeleteEmployees(int idEmployees)
        {

            var EmployeesToDelete = await _EmployeesService.DeleteEmployees(idEmployees);

            if (EmployeesToDelete != null)
            {
                return Ok(EmployeesToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }

}