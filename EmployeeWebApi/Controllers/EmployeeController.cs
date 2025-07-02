using EmployeeWebApi.Interfaces;
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{

    //[Route("/v1/[controller]")] -- giving [controller] will replace that part with EmployeeController class name's first part -- employee ==  so rpute is /v1/employee

    [Route("/v1/employee")]//@RequestMapping in spboot
    [ApiController] // @RestController in spboot
    public class EmployeeController : ControllerBase // extends with ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpGet("get-all")]
        [ProducesResponseType(200, Type = typeof(ICollection<Employee>))] //Declares that this action returns HTTP 200 OK with a body of type ICollection<Employee>.---- better map this to DTO and pass
        public IActionResult GetAll() { //IActionResult is like ResponseEntity
            ICollection<Employee> emps=this._employeeRepository.GetAllEmployees();

            //move this to service
            if (!ModelState.IsValid) {// automatically validates incoming request data based on model attributes (like [Required], [StringLength], etc.).
                return BadRequest(ModelState);
            }
            return Ok(emps); //spboot return ResponseEntity.ok(emps);
        }


    }
}
