using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTreeAPI.Models {
    public class Article: ArticleView
    {  
        [Key]
        public int Id {get; set; }
        public bool Enabled { get; set; }
        public bool EnabledInWeb { get; set; }
    }  

    public class ArticleView
    {  
        public Guid EId { get; set; } = Guid.NewGuid();  
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public ICollection<Keyword>? Keywords { get; set; }
        public ICollection<Person>? Persons { get; set; }  
        public ICollection<Image>? Images { get; set; }
    }
}