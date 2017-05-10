namespace ProjectManagerSystem.Common.Contracts
{
    public interface ILogger
    {
        void GetInfo(object mesage);

        void ShowError(object mesage);

       void ShowFatal(object mesage);
    }
}