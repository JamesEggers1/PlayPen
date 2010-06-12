using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;

namespace PlayPen.Commands
{
    /// <summary>
    /// A MEF-based command manager implementation
    /// </summary>
    public class CommandManager : ICommandManager
    {
        /// <summary>
        /// Commands Collection
        /// </summary>
        [ImportMany("PlayPen.ConsoleCommand", typeof(ConsoleCommandBase))] 
        private Lazy<ConsoleCommandBase, IConsoleCommandMetadata>[] _commands;

        /// <summary>
        /// A path where additional command assemblies could be found.
        /// </summary>
        public string CommandDirectory { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CommandManager()
        {
            LoadCommands();
        }

        /// <summary>
        /// Loads the commands into the Commands collection
        /// </summary>
        private void LoadCommands()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetCallingAssembly()));

            if (!string.IsNullOrEmpty(CommandDirectory))
            {
                catalog.Catalogs.Add(new DirectoryCatalog(CommandDirectory));
            }

            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        /// <summary>
        /// Verifies that a command (by name) exists
        /// </summary>
        /// <param name="name">The name of the command</param>
        /// <returns>true if the command exists, else false</returns>
        public bool CommandExists(string name)
        {
            foreach (var c in _commands)
            {
                if (string.Compare(c.Metadata.Name, name,true) == 0)
                {
                    return true;
                }
            }

            return false;
        }
        
        /// <summary>
        /// Retrieves the command from the collection
        /// </summary>
        /// <param name="name">The name of the command</param>
        /// <returns>The instance of the command else null if not found.</returns>
        public ConsoleCommandBase GetCommand(string name)
        {
            return (from c in _commands
                    where string.Compare(c.Metadata.Name, name, true) == 0
                    select c.Value).FirstOrDefault();
        }
    }
}
