using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;

namespace FamilyTreeAPI.Models
{
    public class Person : PersonBase
    {
        public bool Enabled { get; set; } = true;
        public bool Public { get; set; } = false;
    }

    public class PersonBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstNames { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly? DateOfBirth { get; set; }
        public DateOnly? DateOfDeath { get; set; }
        public Place? PlaceOfBirth { get; set; }
        [ForeignKey("MotherId")]
        public Person? Mother { get; set; }
        [ForeignKey("FatherId")]
        public Person? Father { get; set; }
        public string? BirthName { get; set; }
        public string? Notes { get; set; }
        public bool IsFemale { get; set; } = true;
        //
        public Image? Avatar { get; set; }
        public Branch Branch { get; set; } = default!;
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }

    public class PersonView : PersonBase
    {

    }

    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonView>();

            CreateMap<PersonView, Person>()
                .ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForMember(dest => dest.Enabled, opts => opts.Ignore())
                .ForMember(dest => dest.Public, opts => opts.Ignore());
        }
    }
}