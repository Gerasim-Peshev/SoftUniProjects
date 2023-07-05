using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Classes
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var commands = args.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            ICommand command = null;

            var typeOfCommand = commands[0];
            var argument = commands.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == typeOfCommand + "Command");

            if (type == null)
            {
                throw new InvalidOperationException("Missing command");
            }

            if (type.GetInterface("ICommand") == null)
            {
                throw new InvalidOperationException("Not a command");
            }

            command = Activator.CreateInstance(type) as ICommand;

            return command.Execute(argument);
        }
    }
}
