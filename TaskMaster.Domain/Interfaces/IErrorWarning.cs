namespace TaskMaster.Domain.Interfaces
{
    public interface IErrorWarning
    {
        DateTime CreatedAt { get; set; }
        string? Description { get; set; }
        string Encodedname { get; }
        int Id { get; set; }
        string Title { get; set; }

        void EncodeName();
    }
}