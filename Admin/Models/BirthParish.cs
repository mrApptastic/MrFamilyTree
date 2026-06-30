using System.ComponentModel.DataAnnotations;

namespace MrFamilyTree.Models
{
    public class BirthParish : BirthParishView
    {
        [Key]
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public bool EnabledInWeb { get; set; }
    }

    public class BirthParishView
    {
        public Guid? EId { get; set; }
        public string Names { get; set; } = string.Empty;
        public ICollection<Person>? Persons { get; set; }
    }
}
