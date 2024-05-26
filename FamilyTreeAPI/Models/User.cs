namespace FamilyTreeAPI.Models
{
    public class User
    {
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Branch> Branches { get; set; } = default!;
    }
}