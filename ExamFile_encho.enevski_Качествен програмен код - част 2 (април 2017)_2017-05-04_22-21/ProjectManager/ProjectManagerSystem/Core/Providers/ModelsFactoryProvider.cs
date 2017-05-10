using ProjectManagerSystem.Common.Exceptions;
using ProjectManagerSystem.Core.Providers;
using ProjectManagerSystem.Core.Providers.Contracts;
using ProjectManagerSystem.Models;
using System;

namespace ProjectManagerSystem.Core.Providers
{
    public class ModelsFactoryProvider : IModelsFactory
    {
        private readonly ValidatorProvider validator = new ValidatorProvider();

        public Project CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime starting, end;

            var startingDateSuccessful = DateTime.TryParse(startingDate, out starting);
            var endingDateSuccessful = DateTime.TryParse(endingDate, out end);

            if (!startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            var pj = new Project(name, starting, end, state);
            this.validator.Validate(pj);

            return pj;
        }

        public Task CreateTask(User owner, string name, string state)
        {
            var task = new Task(name, owner, state);
            this.validator.Validate(task);

            return task;
        }

        public User CreateUser(string username, string email)
        {
            var user = new User(email, username);
            this.validator.Validate(user);

            return user;
        }
    }
}