using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Person: PersonView
   {  
       [Key]
       public int Id {get; set; }
       public bool Enabled { get; set; }
       public bool EnabledInWeb { get; set; }
   }  

   public class PersonView
   {  
       public Guid? EId { get; set; }  
       public string FirstNames { get; set; }
       public string LastName { get; set; }
       public DateTime? DateOfBirth { get; set; }
       public DateTime? DateOfDeath { get; set; }
       public int? MotherId { get; set; }
       public int? FatherId { get; set; }
       public string BirthName { get; set; }
       public string Notes { get; set; }     
   }  