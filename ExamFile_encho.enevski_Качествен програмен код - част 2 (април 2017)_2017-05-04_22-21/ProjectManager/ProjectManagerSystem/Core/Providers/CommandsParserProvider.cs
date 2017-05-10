using ProjectManagerSystem.Common.Exceptions;
using ProjectManagerSystem.Core.Commands;
using ProjectManagerSystem.Core.Providers.Contracts;
using ProjectManagerSystem.Data;

namespace ProjectManagerSystem.Core.Providers
{
    public class CommandsParserProvider : IParser
    {
        public CommandsParserProvider(Database dataBase, ModelsFactoryProvider modelFactory)
        {
            this.DataBase = dataBase;
            this.ModelFactory = modelFactory;
        }

        public Database DataBase { get; private set; }

        public ModelsFactoryProvider ModelFactory { get; private set; }

        public ICommand CreateCommandFromString(string commandForParse)
        {
            var comand = this.ParseStringToCommand(commandForParse);

            switch (comand)
            {
                case "createproject": return new CreateProjectCommand(this.DataBase, this.ModelFactory);
                case "createtask": return new CreateTaskCommand();
                case "listprojects": return new ListProjectsCommand(this.DataBase);
                default: throw new UserValidationException("The passed command is not valid!");
            }
        }

        public string ParseStringToCommand(string commandForParse)
        {
            var comand = string.Empty;

            for (int i = 0; i < commandForParse.Length; i++)
            {
                comand += commandForParse[i].ToString().ToLower();
            }

            return comand;
        }
    }
}