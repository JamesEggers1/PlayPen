using System.Collections.Generic;

namespace PlayPen.Arguments
{
    /// <summary>
    /// A basic interface for defining Argument management
    /// </summary>
    public interface IArgumentManager
    {
        /// <summary>
        /// A count of the number of arguments parsed.
        /// </summary>
        int ArgumentCount { get; }

        /// <summary>
        /// A count of the number of flags parsed.
        /// </summary>
        int FlagCount { get; }

        /// <summary>
        /// Retrieves a value from the argument collection
        /// </summary>
        /// <param name="key">The argument key</param>
        /// <returns>The value of the argument of null if not found.</returns>
        string GetArgumentValue(string key);

        /// <summary>
        /// Retrieves true if the glag exists.
        /// </summary>
        /// <param name="key">The flag to retrieve</param>
        /// <returns>True if the key exists else false</returns>
        bool GetFlagValue(string key);
    }
}
