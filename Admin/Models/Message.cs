namespace MrFamilyTree.Models
{
    public class Message
    {
        public string ClientUniqueId { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
