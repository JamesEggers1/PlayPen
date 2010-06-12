using System;
using System.ComponentModel.Composition;

namespace PlayPen.Commands
{
    /// <summary>
    /// A custom attribute for identifying MEF-based Console Commands
    /// used by the CommandManager class.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ConsoleCommandAttribute : ExportAttribute, IConsoleCommandMetadata
    {
        /// <summary>
        /// The metadata element for Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ConsoleCommandAttribute(): base("PlayPen.ConsoleCommand", typeof(ConsoleCommandBase)){}

    }
}
