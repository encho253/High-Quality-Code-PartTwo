using ProjectManagerSystem.Models;

namespace ProjectManagerSystem.Core.Providers.Contracts
{
    /// <summary>
    /// Represents a models that can be loaded by the ModelsFactory.
    /// </summary>
    public interface IModelsFactory
    {
        /// <summary>
        /// Creates the project.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="startingDate">The starting date.</param>
        /// <param name="endingDate">The ending date.</param>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        Project CreateProject(string name, string startingDate, string endingDate, string state);

        /// <summary>
        /// Creates the task.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="name">The name.</param>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        Task CreateTask(User owner, string name, string state);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        User CreateUser(string username, string email);
    }
}