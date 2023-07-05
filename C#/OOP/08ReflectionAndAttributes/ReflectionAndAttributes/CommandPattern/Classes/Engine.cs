using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Classes
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var cmds = Console.ReadLine();
                    Console.WriteLine(this.commandInterpreter.Read(cmds));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }    
        }
    }
}
