using TaskMaster.Domain.Interfaces;

namespace TaskMaster.Domain.Entities
{
    public class Error : IErrorWarning
	{
		public int Id { get; set; }
		public string Title { get; set; } = default!;
		public string Category { get; set; }
		public string? Description { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public string Encodedname { get; private set; } = default!;
		public int Priority { get; set; }
		public string Answer { get; set; } = default!;
		public void EncodeName() => Encodedname = Title.ToLower().Replace(" ", "-");
	}
}