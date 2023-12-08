using TaskMaster.Domain.Entities;

namespace TaskMaster.Domain.Interfaces
{
    public interface IErrorWarning
    {
        DateTime CreatedAt { get; set; }
        string? Description { get; set; }
        string Encodedname { get; }
        int Id { get; set; }
        string Title { get; set; }

        string Answer { get; set; }

        Category Category { get; set; }

        void EncodeName();
    }
}