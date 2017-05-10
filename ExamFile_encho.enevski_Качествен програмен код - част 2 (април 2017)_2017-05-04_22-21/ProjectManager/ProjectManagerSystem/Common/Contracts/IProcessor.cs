using ProjectManagerSystem.Core.Providers;

namespace ProjectManagerSystem.Common.Contracts
{
    public interface IProcessor
    {
        CommandsParserProvider CommandsFactory { get; }

        string ProcessCommandFromInput(string inputCommand);
    }
}