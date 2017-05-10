using System.Collections.Generic;

namespace ProjectManagerSystem.Core.Commands
{
    public interface ICommand
    {
        string Execute(List<string> parameters);
    }
}