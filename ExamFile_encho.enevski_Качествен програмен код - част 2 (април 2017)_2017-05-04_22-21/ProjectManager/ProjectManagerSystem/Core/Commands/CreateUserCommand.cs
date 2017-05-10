using ProjectManagerSystem.Common.Exceptions;
using ProjectManagerSystem.Core.Providers;
using ProjectManagerSystem.Data;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagerSystem.Core.Commands
{
    public class CreateUserCommand : ICommand
    {
        private const string ErrorParametersCount = "Invalid command parameters count!";
        private const string ErrorUserValidation = "Some of the passed parameters are empty!";
        private const string ErrorExistUser = "A project with that name already exists!";
        private const string UserCreated = "Successfully created a new project!";

        public string Execute(List<string> commandsParameters)
        {
            var dataBase = new Database();
            var modelsFactory = new ModelsFactoryProvider();

            if (commandsParameters.Count != 3)
            {
                throw new UserValidationException(ErrorParametersCount);
            }

            if (commandsParameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException(ErrorUserValidation);
            }

            if (dataBase.Projects[int.Parse(commandsParameters[0])].Users.Any() && dataBase.Projects[int.Parse(commandsParameters[0])].Users.Any(x => x.UserName == commandsParameters[1]))
            {
                throw new UserValidationException(ErrorExistUser);
            }

            dataBase.Projects[int.Parse(commandsParameters[0])].Users.Add(modelsFactory.CreateUser(commandsParameters[1], commandsParameters[2]));

            return UserCreated;
        }
    }
}