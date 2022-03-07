// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using Quickstart;
using System.Collections;


namespace Quickstart
{
    public class Program
    {
        static List<QuickstartCommand> commands = new List<QuickstartCommand>();
        public static int Main(string[] args)
        {
            // Setup commands
            SetupCommands();

            List<string> arguments = args.ToList();

            // Get first command we can find
            var command = GetFirstCommandFromArgs(arguments);
            if (command != null)
            {
                arguments.Remove(command.CommandName);
                var commandResult = command.Execute(arguments);
                if (!commandResult.Success)
                {
                    Console.WriteLine(commandResult.Response);
                    return -1;
                }

                Console.WriteLine(commandResult.Response);
                return 0;
            }

            DisplayHelpText(arguments);

            return 0;
        }

        /// <summary>
        /// Set up commands that should be available
        /// </summary>
        internal static void SetupCommands()
        {
            commands.Clear();

            commands.Add(new QuickstartCommand(
                "clone",
                "Clones a repo and displays the last N commits.",
                new Dictionary<string, string> {
                    { "url", "The url to clone." },
                    {"n", "The number of historic commits to display." }
                },
                CloneAndDisplayHistory
            ));

            commands.Add(new QuickstartCommand(
                "help",
                "Displays help for the specified command or all commands in non specified.",
                new Dictionary<string, string> {
                    { "command", "[Optional] The command to view help for." }
                },
                DisplayHelpText
            ));
        }

        internal static CommandResult CloneAndDisplayHistory(List<string> args)
        {
            // Validate we have 2 arguments
            if (args.Count < 2)
            {
                return new CommandResult(false, "url and number of commits must be defined.");
            }

            var url = args[0];
            var numCommits = args[1];

            // Perform clone
            var cloneResult = CLIController.Run($"git clone {url}");

            if (!cloneResult.Success)
            {
                return new CommandResult(false, $"Clone failed: {cloneResult.Output}.");
            }

            var repoFolder = url.Split('/').Last().Split(".")[0];

            // Get commit log
            var logResult = CLIController.Run($"cd repoFolder & git log -n {numCommits} --format=\"%an%n%s%n%b%n\"");

            if (!logResult.Success)
            {
                return new CommandResult(false, $"Failed to list commits: {logResult.Output}.");
            }

            Console.WriteLine(logResult.Output);

            return new CommandResult(true, "Clone Complete...");
        }

        internal static CommandResult DisplayHelpText(List<string> args)
        {
            // Validate we have arguments
            if (args.Count > 0)
            {
                var command = GetFirstCommandFromArgs(args);
                if (command != null)
                {
                    RenderCommandHelpText(command);
                    return new CommandResult(true, "...");
                }

            }

            foreach (var command in commands)
            {
                RenderCommandHelpText(command);
            }

            return new CommandResult(true, "...");
        }

        internal static void RenderCommandHelpText(QuickstartCommand command)
        {
            Console.WriteLine(command.CommandName);
            Console.WriteLine($"\t{command.HelpText}");
            Console.WriteLine();
            if (command.Arguments.Count == 0)
            {
                return;
            }

            Console.WriteLine($"\tArguments:");

            foreach (var argument in command.Arguments)
            {
                Console.WriteLine($"\t\t{argument.Key}\t\t{argument.Value}");
            }
            Console.WriteLine();
        }

        internal static QuickstartCommand? GetFirstCommandFromArgs(List<string> args)
        {
            foreach (var arg in args)
            {
                var command = commands.Where((c) => c.CommandName == arg.ToLower()).FirstOrDefault();
                return command;
            }

            return null;
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