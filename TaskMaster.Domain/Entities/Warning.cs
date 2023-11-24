using TaskMaster.Domain.Interfaces;

namespace TaskMaster.Domain.Entities
{
    public class Warning : IErrorWarning
    {
		public int Id { get; set; }
		public string Title { get; set; } = default!;
		public string? Description { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public string Encodedname { get; private set; } = default!;
		public string? About { get; set; }

		public void EncodeName() => Encodedname = Title.ToLower().Replace(" ", "-");
	}
}