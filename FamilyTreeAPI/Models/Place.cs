using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTreeAPI.Models {
    public class Place: PlaceView
    {  
        [Key]
        public int Id {get; set; }
        public bool Enabled { get; set; }
        public bool EnabledInWeb { get; set; }
    }  

    public class PlaceView
    {  
        public Guid EId { get; set; } = Guid.NewGuid();  
        public string Name { get; set; }
        public Parish Parish { get; set; }    
    }
}