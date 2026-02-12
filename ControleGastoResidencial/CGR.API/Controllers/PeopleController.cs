using CGR.Application.DTOs;
using CGR.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CGR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetPeople()
        {
            var people = await _personService.GetPeopleAsync();
            if (people == null)
            {
                return NotFound("No people found.");
            }

            return Ok(people);
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        public async Task<ActionResult<PersonDTO>> GetPersonById(Guid id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound($"Person with ID {id} not found.");
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePerson([FromBody] PersonDTO personDto)
        {
            if (personDto == null)
            {
                return BadRequest("Person name is required.");
            }
            var person = await _personService.CreateAsync(personDto);

            return new CreatedAtRouteResult("GetPersonById", new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePerson(Guid id, [FromBody] PersonDTO personDto)
        {
            if (personDto == null || id != personDto.Id)
                return BadRequest("Person ID mismatch.");

            try
            {
                await _personService.UpdateAsync(personDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Person with ID {id} not found.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(Guid id)
        {
            var existingPerson = await _personService.GetByIdAsync(id);
            if (existingPerson == null)
            {
                return NotFound($"Person with ID {id} not found.");
            }
            await _personService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("transactions/totals")]
        public async Task<ActionResult> GetPersonTotalTransactions()
        {
            var peopleTransactions = await _personService.GetPeopleTotalSummaryAsync();
            if(peopleTransactions == null)
            {
                return NotFound("No people transactions found.");
            }

            return Ok(peopleTransactions);
        }
    }
}
