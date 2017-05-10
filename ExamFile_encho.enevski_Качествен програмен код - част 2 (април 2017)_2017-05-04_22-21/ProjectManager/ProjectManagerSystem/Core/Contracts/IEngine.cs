using ProjectManagerSystem.Common;
using ProjectManagerSystem.Core.Providers.Contracts;

namespace ProjectManagerSystem.Core.Contracts
{
    /// <summary>
    /// Represents a engine that can be loaded by the Engine.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Gets the command processor.
        /// </summary>
        /// <value>
        /// The command processor.
        /// </value>
        CommandProcessor CommandProcessor { get; }

        /// <summary>
        /// Gets the file logger.
        /// </summary>
        /// <value>
        /// The file logger.
        /// </value>
        FileLogger FileLogger { get; }

        /// <summary>
        /// Gets the reader.
        /// </summary>
        /// <value>
        /// The reader.
        /// </value>
        IReader Reader { get; }

        /// <summary>
        /// Gets the writer.
        /// </summary>
        /// <value>
        /// The writer.
        /// </value>
        IWriter Writer { get;  }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        void Start();
    }
}