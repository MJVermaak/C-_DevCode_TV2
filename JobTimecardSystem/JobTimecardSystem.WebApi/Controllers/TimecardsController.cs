using JobTimecardSystem.Data.Models;
using JobTimecardSystem.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobTimecardSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimecardsController : ControllerBase
    {
        private readonly TimecardRepository _timecardRepo;
        private readonly JobRepository _jobRepo;

        public TimecardsController(TimecardRepository timecardRepo, JobRepository jobRepo)
        {
            _timecardRepo = timecardRepo;
            _jobRepo = jobRepo;
        }

        [HttpGet]
        public ActionResult<List<Timecard>> GetAll([FromQuery] string? search = null)
        {
            return Ok(_timecardRepo.GetAll(search));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var timecard = _timecardRepo.GetById(id);
            return timecard is null ? NotFound($"Timecard with ID {id} not found.") : Ok(timecard);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Timecard timecard)
        {
            if (string.IsNullOrWhiteSpace(timecard.Employee))
                return BadRequest("Employee name is required.");

            if (timecard.HoursWorked <= 0 || timecard.HoursWorked > 24)
                return BadRequest("Hours worked must be between 0.25 and 24.");

            var job = _jobRepo.GetById(timecard.JobId);
            if (job is null)
                return BadRequest($"Job with ID {timecard.JobId} does not exist.");

            timecard.Job = job;
            _timecardRepo.Add(timecard);
            return CreatedAtAction(nameof(GetById), new { id = timecard.Id }, timecard);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Timecard timecard)
        {
            var existing = _timecardRepo.GetById(id);
            if (existing is null)
                return NotFound($"Timecard with ID {id} not found.");

            if (string.IsNullOrWhiteSpace(timecard.Employee))
                return BadRequest("Employee name is required.");

            if (timecard.HoursWorked <= 0 || timecard.HoursWorked > 24)
                return BadRequest("Hours worked must be between 0.25 and 24.");

            var job = _jobRepo.GetById(timecard.JobId);
            if (job is null)
                return BadRequest($"Job with ID {timecard.JobId} does not exist.");

            timecard.Id = id;
            timecard.Job = job;
            _timecardRepo.Update(timecard);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var existing = _timecardRepo.GetById(id);
            if (existing is null)
                return NotFound($"Timecard with ID {id} not found.");

            _timecardRepo.Delete(id);
            return NoContent();
        }
    }
}