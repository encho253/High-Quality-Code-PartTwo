using ProjectManagerSystem.Common.Contracts;
using ProjectManagerSystem.Core.Providers;
using System;
using System.Linq;

namespace ProjectManagerSystem.Common
{
    public class CommandProcessor : IProcessor
    {
        private const string ErrorWhenNull = "No command has been provided!";

        public CommandProcessor(CommandsParserProvider commandsFactory)
        {
            this.CommandsFactory = commandsFactory;
        }

        public CommandsParserProvider CommandsFactory { get; set; }

        public string ProcessCommandFromInput(string inputCommand)
        {
            if (string.IsNullOrWhiteSpace(inputCommand))
            {
                throw new Exceptions.UserValidationException(ErrorWhenNull);
            }

            if (inputCommand.Split(' ').Count() > 10)
            {
                throw new ArgumentException();
            }

            var command = this.CommandsFactory.CreateCommandFromString(inputCommand.Split(' ')[0]);

            return command.Execute(inputCommand.Split(' ').Skip(1).ToList());
        }
    }
}