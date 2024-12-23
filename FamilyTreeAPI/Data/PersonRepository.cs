using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FamilyTreeAPI.Models;

namespace FamilyTreeAPI.Data
{
	public interface IPersonRepository {
        Task<PersonView> GetPersonAsync(Guid externalId, bool onlyEnabledForWeb = true);
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

        public async Task<PersonView> GetPersonAsync(Guid id, bool onlyPublic = true) 
        {
            var person = await _context.FamilyTreePersons
                                       .Where(x => x.Id == id && 
                                                   (onlyPublic ? x.Public : true)
                                        )
                                        .Include(x => x.Mother).ThenInclude(y => y.Father).ThenInclude(y => y.Mother)
                                        .Include(x => x.Father).ThenInclude(y => y.Father).ThenInclude(y => y.Mother)
                                        .FirstOrDefaultAsync();
            
            if (person == null) {
                var expt = new ArgumentException("The requested person does not exist");
                _logger.LogError(expt.Message);
                throw expt;
            }

            return _mapper.Map<Person, PersonView>(person);
        }        
    }
}