using Microsoft.AspNetCore.Identity;
using TaskMaster.Domain.Interfaces;

namespace TaskMaster.Domain.Entities
{
    public class Error : IErrorWarning
	{
		private readonly UserManager<IdentityUser> _userManager;

        public int Id { get; set; }
		public string Title { get; set; } = default!;

		public int CategoryId { get; set; }
		public Category? Category { get; set; }
        public string? Description { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public string Encodedname { get; private set; } = default!;
		public int PriorityId { get; set; }
		public Priority? Priority { get; set; }
        public string? Answer { get; set; } = default!;
		public string UserId { get; set; }

        public ApplicationUser User { get; set; }


        public void EncodeName() => Encodedname = Title.ToLower().Replace(" ", "-");
	}	
}