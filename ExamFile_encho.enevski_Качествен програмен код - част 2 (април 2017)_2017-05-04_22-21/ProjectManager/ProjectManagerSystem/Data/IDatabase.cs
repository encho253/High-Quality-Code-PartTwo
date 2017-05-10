using ProjectManagerSystem.Models.Contracts;
using System.Collections.Generic;

namespace ProjectManagerSystem.Data
{
    /// <summary>
    /// Represents the database that can be loaded by the Database
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <value>
        /// The projects.
        /// </value>
        IList<IProject> Projects { get; }
    }
}