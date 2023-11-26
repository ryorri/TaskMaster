namespace TaskMaster.Domain.Interfaces
{
    public interface IErrorWarning
    {
        DateTime CreatedAt { get; set; }
        string? Description { get; set; }
        string Encodedname { get; }
        int Id { get; set; }
        string Title { get; set; }

        int Priority { get; set; }
        string Answer { get; set; }

        string Category { get; set; }

        void EncodeName();
    }
}