using System.ComponentModel.DataAnnotations;

namespace MrFamilyTree.Models
{
    public class Person : PersonView
    {
        [Key]
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public bool EnabledInWeb { get; set; }
    }

    public class PersonView
    {
        public Guid? EId { get; set; }
        public string FirstNames { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public int? MotherId { get; set; }
        public int? FatherId { get; set; }
        public string? BirthName { get; set; }
        public string? Notes { get; set; }
    }
}
