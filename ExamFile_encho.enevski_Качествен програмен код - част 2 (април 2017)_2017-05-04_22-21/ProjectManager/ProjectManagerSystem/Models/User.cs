using ProjectManagerSystem.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManagerSystem.Models
{
    public class User : IUser
    {
        public User(string username, string email)
        {
            this.UserName = username;
            this.Email = email;
        }

        [Required(ErrorMessage = "User Username is required!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User Email is required!")]
        [EmailAddress(ErrorMessage = "User Email is not valid!")]
        public string Email { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("    Username: " + this.UserName);
            stringBuilder.AppendLine("    Email: " + this.Email);

            return stringBuilder.ToString();
        }
    }
}