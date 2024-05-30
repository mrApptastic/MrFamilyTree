using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FamilyTreeAPI.Models;
using FamilyTreeAPI.Data;

namespace FamilyTreeAPI.Controllers
{
    [ApiController, Authorize, Route("Api/[controller]")]
    public class FamilyTreeController : ControllerBase
    {
        private readonly ILogger<FamilyTreeController> _logger;
        private readonly IPersonRepository _personRepository;

        public FamilyTreeController(ILogger<FamilyTreeController> logger, IPersonRepository personRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
        }

        [HttpGet("Person/{ExternalId}")]
        public async Task<ActionResult<PersonView>> GetPerson([FromRoute] Guid ExternalId)
        {
            return  Ok(await _personRepository.GetPersonAsync(ExternalId));
        } 
    }
}