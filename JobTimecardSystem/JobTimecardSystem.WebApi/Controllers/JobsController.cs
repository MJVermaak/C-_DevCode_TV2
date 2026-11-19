using JobTimecardSystem.Data.Models;
using JobTimecardSystem.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobTimecardSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobRepository _repo;

        public JobsController(JobRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var job = _repo.GetById(id);
            return job is null ? NotFound($"Job with ID {id} not found.") : Ok(job);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Job job)
        {
            if (string.IsNullOrWhiteSpace(job.JobNumber) || string.IsNullOrWhiteSpace(job.CompanyName))
                return BadRequest("Job Number and Company Name are required.");

            _repo.Add(job);
            return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Job job)
        {
            var existing = _repo.GetById(id);
            if (existing is null)
                return NotFound($"Job with ID {id} not found.");

            if (string.IsNullOrWhiteSpace(job.JobNumber) || string.IsNullOrWhiteSpace(job.CompanyName))
                return BadRequest("Job Number and Company Name are required.");

            job.Id = id;
            _repo.Update(job);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var existing = _repo.GetById(id);
            if (existing is null)
                return NotFound($"Job with ID {id} not found.");

            _repo.Delete(id);
            return NoContent();
        }
    }
}