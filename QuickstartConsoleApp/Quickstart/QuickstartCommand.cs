// See https://aka.ms/new-console-template for more information
using System.Collections.Immutable;


namespace Quickstart
{
    /// <summary>
    /// Container for all CLI commands.
    /// </summary>
    public class QuickstartCommand
    {
        string _commandName;
        public string CommandName { get => _commandName; }

        string _helpText;
        public string HelpText { get => _helpText; }

        Dictionary<string, string> _arguments;
        public IReadOnlyDictionary<string, string> Arguments;
        Func<List<string>, CommandResult> _function;

        /// <summary>
        /// Container for all CLI commands
        /// </summary>
        /// <param name="commandName">Command name that should be used on the command line. Will always be lowercase.</param>
        /// <param name="helpText">Help text that will be displayed for this command.</param>
        /// <param name="arguments">Dictionary of each argument with it's help text.</param>
        /// <param name="function">The action to perform when this command is executed. Must take a list of string arguments and return a CommandResult.</param>
        public QuickstartCommand(string commandName, string helpText, Dictionary<string, string> arguments, Func<List<string>, CommandResult> function)
        {
            _commandName = commandName.ToLower();
            _helpText = helpText;
            _arguments = arguments;
            _function = function;
            Arguments = _arguments.ToImmutableDictionary();
        }

        /// <summary>
        /// Executes the command and returns it's result.
        /// </summary>
        /// <param name="arguments">The arguments to execute with.</param>
        /// <returns>CommandResult containing success and response text.</returns>
        public CommandResult Execute(List<string> arguments)
        {
            return _function(arguments);
        }
    }

    public struct CommandResult
    {
        public bool Success;
        public string Response;

        public CommandResult(bool success, string response)
        {
            Success = success;
            Response = response;
        }
    }
}

// • Clone a git repository and list the author’s name and commit message for X number of commits
//   o The user must be able to specify the git URL
//   o The user should be able to specify the number of commits to retrieve
//   o The tool won’t use APIs of the repository host e.g. GitHub’s APIs
// • Create a .NET console application, create a Git repository, commit the console application to the git repository
//   o The user must be able to specify the console application’s name
//   o The user could be able to specify the commit message
// • Provide help and usage information for all commands


// Take url + number of commits -> return list of commit messages + authors name
// Take application name + commit message -> return success/failure?
// Take command -> return command info