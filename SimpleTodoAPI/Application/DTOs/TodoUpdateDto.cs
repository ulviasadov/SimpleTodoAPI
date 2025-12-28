namespace SimpleTodoAPI.Application.DTOs
{
    public class TodoUpdateDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? BodyText { get; set; }
    }
}
