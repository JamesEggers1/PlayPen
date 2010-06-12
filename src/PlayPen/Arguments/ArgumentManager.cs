using System.Collections.Generic;

namespace PlayPen.Arguments
{
    /// <summary>
    /// Command line argument parser
    /// </summary>
    /// <remarks>
    /// Argument Convention: -key:value
    /// Flag Convention: -key
    /// </remarks>
    public class ArgumentManager : IArgumentManager
    {
        private Dictionary<string, string> _arguments;
        private List<string> _flags;
        private const char PREFIX = '-';
        private const char SEPARATOR = ':';

        /// <summary>
        /// A count of the number of arguments parsed.
        /// </summary>
        public int ArgumentCount { get { return _arguments.Count; } }

        /// <summary>
        /// A count of the number of flags parsed.
        /// </summary>
        public int FlagCount { get { return _flags.Count; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args">The array of string-based command line arguments</param>
        public ArgumentManager(string[] args)
        {
            _arguments = new Dictionary<string, string>();
            _flags = new List<string>();
            ParseArguments(args);
        }

        /// <summary>
        /// Parses a string array of arguments.
        /// </summary>
        /// <param name="args">The string array to parse</param>
        private void ParseArguments(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                return;
            }

            foreach(var arg in args)
            {
                if (arg[0] == PREFIX)
                {
                    if (arg.IndexOf(SEPARATOR) >= 0)
                    {
                        AddArgument(arg);
                    }
                    else
                    {
                        AddFlag(arg);
                    }
                }
            }
        }

        /// <summary>
        /// Adds an argument to the argument collection
        /// </summary>
        /// <param name="arg">A string argument</param>
        private void AddArgument(string arg)
        {
            var parts = arg.Split(SEPARATOR);
            _arguments.Add(parts[0], parts[1]);
        }
        
        /// <summary>
        /// Adds an argument to the flags collection
        /// </summary>
        /// <param name="key">The string argument</param>
        private void AddFlag(string key)
        {
            _flags.Add(key);
        }

        /// <summary>
        /// Retrieves a value from the argument collection
        /// </summary>
        /// <param name="key">The argument key</param>
        /// <returns>The value of the argument of null if not found.</returns>
        public string GetArgumentValue(string key)
        {
            if (_arguments.ContainsKey(key))
            {
                return _arguments[key];
            }

            return null;
        }

        /// <summary>
        /// Retrieves true if the glag exists.
        /// </summary>
        /// <param name="key">The flag to retrieve</param>
        /// <returns>True if the key exists else false</returns>
        public bool GetFlagValue(string key)
        {
            if (_flags.Contains(key))
            {
                return true;
            }

            return false;
        }
        
    }
}
