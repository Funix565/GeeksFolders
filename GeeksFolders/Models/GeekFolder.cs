namespace GeeksFolders.Models
{
    public class GeekFolder
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Self-referencing relationship
        public int? ParentId { get; set; }
        public GeekFolder? Parent { get; set; }

        public ICollection<GeekFolder>? Children { get; set; }
    }
}
