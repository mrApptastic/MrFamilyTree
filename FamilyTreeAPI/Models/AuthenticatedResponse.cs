namespace FamilyTreeAPI.Models {
    public class AuthenticatedResponse
    {
        public string User { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}