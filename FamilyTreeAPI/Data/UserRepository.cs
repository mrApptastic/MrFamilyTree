using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FamilyTreeAPI.Models;

namespace FamilyTreeAPI.Data
{
	public interface IUserRepository {
        Task<User?> GetUser(string name, string password);
    }

    public class UserRepository: IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        
        public UserRepository(ILogger<UserRepository> logger, IMapper mapper, ApplicationDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<User?> GetUser(string name, string password) 
        {
            return await _context.FamilyTreeUsers.Where(x => x.Name == name && x.Password == password).FirstOrDefaultAsync();
        }        
    }
}