using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FamilyTreeAPI.Models;

namespace FamilyTreeAPI.Data
{
	public interface IPersonRepository {
        Task<PersonView> GetPersonAsync(Guid externalId);
    }

    public class PersonRepository: IPersonRepository
    {
        private readonly ILogger<PersonRepository> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        
        public PersonRepository(ILogger<PersonRepository> logger, IMapper mapper, ApplicationDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<PersonView> GetPersonAsync(Guid externalId) 
        {
            var person = await _context.FamilyTreePersons.Where(x => x.EId == externalId).FirstOrDefaultAsync();
            
            if (person == null) {
                var expt = new ArgumentException("The requested person does not exist");
                _logger.LogError(expt.Message);
                throw expt;
            }

            return _mapper.Map<Person, PersonView>(person);
        }        
    }
}