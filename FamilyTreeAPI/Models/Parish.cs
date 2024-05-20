using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTreeAPI.Models {
    public class Parish: ParishView
    {  
        [Key]
        public int Id {get; set; }
        public bool Enabled { get; set; }
        public bool EnabledInWeb { get; set; }
    }  

    public class ParishBase
    {  
        public Guid EId { get; set; } = Guid.NewGuid();   
        public string Name { get; set; } = string.Empty;  
    }

    public class ParishView : ParishBase
    {  
 
    }
}