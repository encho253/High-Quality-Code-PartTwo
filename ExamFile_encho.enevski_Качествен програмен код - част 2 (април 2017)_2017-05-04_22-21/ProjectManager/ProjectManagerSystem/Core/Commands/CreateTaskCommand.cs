using ProjectManagerSystem.Common.Exceptions;
using ProjectManagerSystem.Core.Providers;
using ProjectManagerSystem.Data;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagerSystem.Core.Commands
{
    public class CreateTaskCommand : ICommand
    {
        private const string ErrorParametersCount = "Invalid command parameters count!";
        private const string ErrorUserValidation = "Some of the passed parameters are empty!";
        private const string TaskCreated = "Successfully created a new project!";

        public string Execute(List<string> commandsParameters)
        {
            var dataBase = new Database();

            var modelsFactory = new ModelsFactoryProvider();

            if (commandsParameters.Count != 4)
            {
                throw new UserValidationException(ErrorParametersCount);
            }

            if (commandsParameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException(ErrorUserValidation);
            }
            
            var project = dataBase.Projects[int.Parse(commandsParameters[0])];

            var owner = project.Users[int.Parse(commandsParameters[1])];

            var task = modelsFactory.CreateTask(owner, commandsParameters[2], commandsParameters[3]);
            project.Tasks.Add(task);

            return TaskCreated;
        }
    }
}