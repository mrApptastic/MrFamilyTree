using System.ComponentModel.DataAnnotations;

namespace MrFamilyTree.Models
{
    public class Image : ImageView
    {
        [Key]
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public bool EnabledInWeb { get; set; }
    }

    public class ImageView
    {
        public Guid? EId { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Keyword>? Keywords { get; set; }
        public ICollection<Person>? Persons { get; set; }
    }
}
