namespace PlayPen.Commands
{
    /// <summary>
    /// An abstract base class for all console commands to inherit from.
    /// </summary>
    public abstract class ConsoleCommandBase
    {
        /// <summary>
        /// What the command is responsible for doing.
        /// </summary>
        public abstract void Execute();
    }
}
