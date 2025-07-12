using Api.Model;
using Api.Repos;
using Api.RequestDtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _employeeRepository.GetAll();
            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _employeeRepository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] AddEmployeeRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _employeeRepository.Add(request);
            if (result == "Success.")
            {
                return Ok("Employee added successfully.");
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployeeRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingEmployee = _employeeRepository.GetById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            else
            {
                var result = _employeeRepository.Update(id, request);
                if (result == "Success.")
                {
                    return Ok("Employee updated successfully.");
                }
                else
                {
                    return BadRequest(result);
                }
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _employeeRepository.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            var result = _employeeRepository.Delete(id);
            if (result == "Success.")
            {
                return Ok("Employee deleted successfully.");
            }

            else
            {
                return BadRequest(result);
            }
        }
    }
}
