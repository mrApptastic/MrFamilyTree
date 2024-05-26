using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTreeAPI.Models
{
    public class Place : PlaceView
    {
        [Key]
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        public bool EnabledInWeb { get; set; } = false;
    }

    public class PlaceView
    {
        public Guid EId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public decimal? Altitude { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public Branch Branch { get; set; } = default!;
    }
}