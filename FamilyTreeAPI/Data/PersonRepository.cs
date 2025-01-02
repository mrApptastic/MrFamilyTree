using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FamilyTreeAPI.Models;

namespace FamilyTreeAPI.Data
{
    public interface IPersonRepository
    {
        Task<PersonView> GetPersonAsync(Guid externalId, bool onlyEnabledForWeb = true);
    }

    public class PersonRepository : IPersonRepository
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

        public async Task<PersonView> GetPersonWithGenerationsAsync(Guid id, bool onlyPublic = true)
        {
            var personWithGenerations =
            await _context.FamilyTreePersons
                    .Include(p => p.Mother)
                        .ThenInclude(m => m.Mother)
                            .ThenInclude(mm => mm.Mother)
                                .ThenInclude(mmm => mmm.Mother)
                                    .ThenInclude(mmmm => mmmm.Mother)
                    .Include(p => p.Mother)
                        .ThenInclude(m => m.Father)
                            .ThenInclude(mf => mf.Mother)
                                .ThenInclude(mfm => mfm.Mother)
                                    .ThenInclude(mfmm => mfmm.Mother)
                    .Include(p => p.Father)
                        .ThenInclude(f => f.Mother)
                            .ThenInclude(fm => fm.Mother)
                                .ThenInclude(fmm => fmm.Mother)
                                    .ThenInclude(fmmm => fmmm.Mother)
                    .Include(p => p.Father)
                        .ThenInclude(f => f.Father)
                            .ThenInclude(ff => ff.Mother)
                                .ThenInclude(ffm => ffm.Mother)
                                    .ThenInclude(ffmm => ffmm.Mother)
                 .FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<Person, PersonView>(personWithGenerations);
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

            if (person == null)
            {
                var expt = new ArgumentException("The requested person does not exist");
                _logger.LogError(expt.Message);
                throw expt;
            }

            return _mapper.Map<Person, PersonView>(person);
        }
    }
}