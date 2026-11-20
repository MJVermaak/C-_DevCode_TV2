using JobTimecardSystem.Data.Models;
using JobTimecardSystem.Data.Models.JobTimecardSystem.Data.Models;
using JobTimecardSystem.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobTimecardSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientRepository _repo;

        public ClientsController(ClientRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Client>> GetAll([FromQuery] string? search = null)
        {
            return Ok(_repo.GetAll(search));
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetById(int id)
        {
            var client = _repo.GetById(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public ActionResult<Client> Create([FromBody] Client client)
        {
            if (string.IsNullOrWhiteSpace(client.CompanyName) ||
                string.IsNullOrWhiteSpace(client.ContactName) ||
                string.IsNullOrWhiteSpace(client.TelephoneNumber))
            {
                return BadRequest("Company Name, Contact Name, and Telephone Number are required.");
            }

            var created = _repo.Add(client);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Client client)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return NotFound();

            if (string.IsNullOrWhiteSpace(client.CompanyName) ||
                string.IsNullOrWhiteSpace(client.ContactName) ||
                string.IsNullOrWhiteSpace(client.TelephoneNumber))
            {
                return BadRequest("Company Name, Contact Name, and Telephone Number are required.");
            }

            client.Id = id;
            _repo.Update(client);
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