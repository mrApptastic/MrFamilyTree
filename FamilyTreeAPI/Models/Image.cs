using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTreeAPI.Models
{
    public class Image : ImageView
    {        
        public bool Enabled { get; set; } = true;
        public bool Public { get; set; } = false;
    }

    public class ImageView
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Branch Branch { get; set; } = default!;
        public Place? Place { get; set;}
        public ICollection<Keyword>? Keywords { get; set; }   
        public ICollection<Person>? Persons { get; set; }
    }
}