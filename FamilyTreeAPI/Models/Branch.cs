using System.ComponentModel.DataAnnotations;

namespace FamilyTreeAPI.Models
{
    public class Branch : BranchBase
    {
        public bool Enabled { get; set; } = true;
        public bool Public { get; set; } = false;
    }
    
    public class BranchBase
    {       
        [Key] 
        public Guid Id { get; set; } = Guid.NewGuid();  
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;        
        public List<User>? Users { get; set; }
    }
}