namespace ProjectManagerSystem.Models.Contracts
{
    public interface ITask
    {
        string Name { get; }

        User Owner { get; }

        string State { get; }
    }
}
