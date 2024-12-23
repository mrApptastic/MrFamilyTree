using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTreeAPI.Models
{
    public class Keyword : KeywordView
    {
        public bool Enabled { get; set; } = true;
        public bool Public { get; set; } = false;
    }

    public class KeywordView
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Branch Branch { get; set; } = default!;
        public ICollection<Image>? Images{ get; set; }
    }
}