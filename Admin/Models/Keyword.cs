using System.ComponentModel.DataAnnotations;

namespace MrFamilyTree.Models
{
    public class Keyword : KeywordView
    {
        [Key]
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public bool EnabledInWeb { get; set; }
    }

    public class KeywordView
    {
        public Guid? EId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
