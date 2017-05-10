﻿using ProjectManagerSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManagerSystem.Models
{
    public class Project : IProject
    {            
        public Project(string name, DateTime startingDate, DateTime endingDate, string state)
        {
            this.Name = name;
            this.StartingDate = startingDate;
            this.EndingDate = endingDate;
            this.State = state;
            this.Users = new List<User>();
            this.Tasks = new List<Task>();
        }

        [Required(ErrorMessage = "Project Name is required!")]
        public string Name { get; set; }

        [Range(typeof(DateTime), "1800-1-1", "2017-1-1", ErrorMessage = "Project StartingDate must be between 1800-1-1 and 2017-1-1!")]
        public DateTime StartingDate { get; set; }

        [Range(typeof(DateTime), "2018-1-1", "2144-1-1", ErrorMessage = "Project EndingDate must be between 2018-1-1 and 2144-1-1!")]
        public DateTime EndingDate { get; set; }

        public string State { get; set; }

        public virtual List<User> Users { get; set; }

        public virtual List<Task> Tasks { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Name: " + this.Name);
            stringBuilder.AppendLine("  Starting date: " + this.StartingDate.ToString("yyyy-MM-dd"));
            stringBuilder.AppendLine("  Ending date: " + this.EndingDate.ToString("yyyy-MM-dd"));
            stringBuilder.AppendLine("  State: " + this.State);
            stringBuilder.AppendLine("  Users: ");

            stringBuilder.Append(string.Join(Environment.NewLine + "  -------------" + Environment.NewLine, this.Users));

            if (this.Users.Count == 0)
            {
                stringBuilder.AppendLine("  - This project has no users!");
                stringBuilder.AppendLine("  Tasks: ");
                stringBuilder.Append(string.Join(Environment.NewLine + "  -------------" + Environment.NewLine, this.Tasks));
            }

            if (this.Tasks.Count == 0)
            {
                stringBuilder.Append("  - This project has no tasks!");
            }

            return stringBuilder.ToString();
        }
    }
}