using Bytes2you.Validation;
using ProjectManagerSystem.Common.Exceptions;
using ProjectManagerSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagerSystem.Core.Commands
{
    public class ListProjectsCommand : ICommand
    {
        public ListProjectsCommand(Database dataBase)
        {
            Guard.WhenArgument(dataBase, "ListProjectsCommand Database").IsNull().Throw();
            this.DataBase = dataBase;
        }

        public Database DataBase { get; private set; }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            return string.Join(Environment.NewLine, this.DataBase.Projects);
        }
    }
}