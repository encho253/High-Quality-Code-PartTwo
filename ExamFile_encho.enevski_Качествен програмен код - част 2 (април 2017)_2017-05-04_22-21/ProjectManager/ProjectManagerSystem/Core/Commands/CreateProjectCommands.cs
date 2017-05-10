using Bytes2you.Validation;
using ProjectManagerSystem.Common.Exceptions;
using ProjectManagerSystem.Core.Providers;
using ProjectManagerSystem.Data;
using ProjectManagerSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagerSystem.Core.Commands
{
    public class CreateProjectCommand : ICommand
    {
        private const string ErrorParametersCount = "Invalid command parameters count!";
        private const string ErrorUserValidation = "Some of the passed parameters are empty!";
        private const string ErrorExistUser = "A project with that name already exists!";
        private const string ProjectCreated = "Successfully created a new project!";

        private Database dataBase;
        private ModelsFactoryProvider modelsFactory;

        public CreateProjectCommand(Database database, ModelsFactoryProvider factory)
        {
            Guard.WhenArgument(database, "CreateProjectCommand Database").IsNull().Throw();
            Guard.WhenArgument(
                factory, "CreateProjectCommand ModelsFactory")
                .IsNull().Throw();

            this.dataBase = database;
            this.modelsFactory = factory;
        }

        public string Execute(List<string> commandsParameters)
        {
            if (commandsParameters.Count != 4)
            {
                throw new UserValidationException(ErrorParametersCount);
            }

            if (commandsParameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException(ErrorUserValidation);
            }

            if (this.dataBase.Projects.Any(x => x.Name == commandsParameters[0]))
            {
                throw new UserValidationException(ErrorExistUser);
            }

            var project = this.modelsFactory.CreateProject(commandsParameters[0], commandsParameters[1], commandsParameters[2], commandsParameters[3]);
            this.dataBase.Projects.Add(project);

            return ProjectCreated;
        }
    }
}