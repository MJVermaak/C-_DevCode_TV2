using JobTimecardSystem.Data.Models;
using JobTimecardSystem.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobTimecardSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository _repo;

        public EmployeesController(EmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAll([FromQuery] string? search = null)
        {
            return Ok(_repo.GetAll(search));
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var employee = _repo.GetById(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> Create([FromBody] Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.EmployeeCode) ||
                string.IsNullOrWhiteSpace(employee.FirstName) ||
                string.IsNullOrWhiteSpace(employee.LastName))
            {
                return BadRequest("Employee Code, First Name, and Last Name are required.");
            }

            var created = _repo.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Employee employee)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return NotFound();

            if (string.IsNullOrWhiteSpace(employee.EmployeeCode) ||
                string.IsNullOrWhiteSpace(employee.FirstName) ||
                string.IsNullOrWhiteSpace(employee.LastName))
            {
                return BadRequest("Employee Code, First Name, and Last Name are required.");
            }

            employee.Id = id;
            _repo.Update(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_repo.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}