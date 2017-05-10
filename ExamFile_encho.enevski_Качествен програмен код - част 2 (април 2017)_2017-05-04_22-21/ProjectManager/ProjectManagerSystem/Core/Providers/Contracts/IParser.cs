using ProjectManagerSystem.Core.Commands;
using ProjectManagerSystem.Data;

namespace ProjectManagerSystem.Core.Providers.Contracts
{
    /// <summary>
    /// Represents a parser that can be loaded by the ParserProvider.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Gets the data base.
        /// </summary>
        /// <value>
        /// The data base.
        /// </value>
        Database DataBase { get; }

        /// <summary>
        /// Gets the model factory.
        /// </summary>
        /// <value>
        /// The model factory.
        /// </value>
        ModelsFactoryProvider ModelFactory { get; }

        /// <summary>
        /// Creates the command from string.
        /// </summary>
        /// <param name="commandForParse">The command for parse.</param>
        /// <returns></returns>
        ICommand CreateCommandFromString(string commandForParse);

        /// <summary>
        /// Parses the string to command.
        /// </summary>
        /// <param name="commandForParse">The command for parse.</param>
        /// <returns></returns>
        string ParseStringToCommand(string commandForParse);
    }
}