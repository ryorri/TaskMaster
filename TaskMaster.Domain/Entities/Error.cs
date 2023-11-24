using TaskMaster.Domain.Interfaces;

namespace TaskMaster.Domain.Entities
{
    public class Error : IErrorWarning
	{
		public int Id { get; set; }
		public string Title { get; set; } = default!;
		public string? Description { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public string Encodedname { get; private set; } = default!;

		public string Priority { get; set; } = "Low";

		public void EncodeName() => Encodedname = Title.ToLower().Replace(" ", "-");
	}
}