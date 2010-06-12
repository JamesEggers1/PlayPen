namespace PlayPen.Commands
{
    /// <summary>
    /// An interface for Command Managers
    /// </summary>
    public interface ICommandManager
    {
        /// <summary>
        /// A path where additional command assemblies could be found.
        /// </summary>
        string CommandDirectory { get; set; }

        /// <summary>
        /// Verifies that a command (by name) exists
        /// </summary>
        /// <param name="name">The name of the command</param>
        /// <returns>true if the command exists, else false</returns>
        bool CommandExists(string name);

        /// <summary>
        /// Retrieves the command from the collection
        /// </summary>
        /// <param name="name">The name of the command</param>
        /// <returns>The instance of the command else null if not found.</returns>
        ConsoleCommandBase GetCommand(string name);
    }
}
