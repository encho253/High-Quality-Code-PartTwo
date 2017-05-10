using System;
using System.Collections.Generic;

namespace ProjectManagerSystem.Models.Contracts
{
    public interface IProject
    {
        string Name { get; set; }

        DateTime EndingDate { get; set; }

        string State { get; set; }

        List<User> Users { get; set; }

        List<Task> Tasks { get; set; }
    }
}