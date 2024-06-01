using System.ComponentModel.DataAnnotations;

namespace FamilyTreeAPI.Models
{
    public class Branch : BranchBase
    {
        [Key]
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        public bool EnabledInWeb { get; set; } = false;
    }
    
    public class BranchBase
    {        
        public Guid EId { get; set; } = Guid.NewGuid();  
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;        
        public List<User>? Users { get; set; }
    }
}