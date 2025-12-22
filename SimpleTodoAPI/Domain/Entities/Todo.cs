using SimpleTodoAPI.Domain.Common;

namespace SimpleTodoAPI.Domain.Entities
{
    public class Todo : BaseEntity
    {
        public string? Title { get; set; }
        public string? BodyText { get; set; }
    }
}
