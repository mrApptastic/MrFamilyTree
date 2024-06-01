using System.ComponentModel.DataAnnotations;

namespace FamilyTreeAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Branch>? Branches { get; set; }
    }
}