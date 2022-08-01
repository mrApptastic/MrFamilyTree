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
        public Guid? EId { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public ICollection<Keyword> Keywords { get; set; }  
        public ICollection<Person> Persons { get; set; }       
    }
}