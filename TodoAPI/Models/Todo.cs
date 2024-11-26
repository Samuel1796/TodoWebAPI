namespace TodoAPI.Models
{
    public class Todo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Description { get; set; }

    }
}
