namespace ProjectManagerSystem.Models.Contracts
{
    public interface IUser
    {
        string UserName { get; }

        string Email { get; }
    }
}