using ProjectManagerSystem.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManagerSystem.Models
{
    public class Task : ITask
    {  
        public Task(string name, User owner, string state)
        {
            this.Name = name;
            this.Owner = owner;
            this.State = state;
        }

        [Required(ErrorMessage = "Task Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Task Owner is required")]
        public User Owner { get; set; }

        public string State { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("    Name: " + this.Name);
            stringBuilder.Append("    State: " + this.State);

            return stringBuilder.ToString();
        }
    }
}