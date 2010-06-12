namespace PlayPen.Commands
{
    /// <summary>
    /// An interface for MEF to strongly type the metadata during import.
    /// </summary>
    public interface IConsoleCommandMetadata
    {
        /// <summary>
        /// The Name of the command
        /// </summary>
        string Name { get; }
    }
}
