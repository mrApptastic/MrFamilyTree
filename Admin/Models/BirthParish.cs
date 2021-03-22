using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BirthParish: BirthParishView
   {  
       [Key]
       public int Id {get; set; }
       public bool Enabled { get; set; }
       public bool EnabledInWeb { get; set; }
   }  

   public class BirthParishView
   {  
       public Guid? EId { get; set; }  
       public string Names { get; set; }
       public ICollection<Person> Persons { get; set; }        
   }  