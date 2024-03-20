using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Records.Peoples;
using System.Net.Mime;
namespace API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   [Produces(MediaTypeNames.Application.Json)]
   public class PeopleController : ControllerBase
   {
      public readonly IPeopleService _peopleService;

      public PeopleController(IPeopleService peopleService)
      {
         _peopleService = peopleService;
      }

      [HttpGet]
      [ProducesResponseType(typeof(List<PeopleItem>), StatusCodes.Status200OK)]
      public async Task<List<PeopleItem>> GetPeoples()
      {
         return await _peopleService.GetAllAsync();
      }

      [HttpGet("{id}")]
      [ProducesResponseType(typeof(PeopleItem), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      public async Task<ActionResult> GetPeopleById(int id)
      {
         var model = await _peopleService.FindAsync(id);
         if (model == null)
         {
            return NotFound();
         }
         return Ok(model);
      }

      [HttpPost]
      [ProducesResponseType(typeof(PeopleItem), StatusCodes.Status201Created)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<ActionResult> PostPeople([FromBody] PeopleCreate model)
      {
         if (ModelState.IsValid)
         {
            var result = await _peopleService.CreateAsync(model);
            if (result == null)
            {
               return BadRequest();
            }
            return CreatedAtAction(nameof(GetPeopleById), new { id = result.Id }, result);
         }
         return BadRequest();
      }

      [HttpPut("{id}")]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<ActionResult> PutPeople(int id, [FromBody] PeopleEdit model)
      {
         if (ModelState.IsValid)
         {
            await _peopleService.EditAsync(model);
            return NoContent();
         }
         return BadRequest();
      }

      [HttpDelete("{id}")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      public async Task<ActionResult> Delete(int id)
      {
         var result = await _peopleService.DeleteAsync(id);
         if (result)
         {
            return Ok(result);
         }
         return NotFound();
      }
   }
}
