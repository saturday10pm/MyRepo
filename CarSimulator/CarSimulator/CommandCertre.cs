using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    class CommandCertre
    {
        private Grid grid;

        static void Main(string[] args)
        {
            CommandCertre commandCertre = new CommandCertre();

            Console.WriteLine("Enter command(Q to quit):");

            string command = Console.ReadLine();
            
            while (!command.Equals("Q"))
            {
                String result = commandCertre.grid.executeCommand(command);
                if (result != null)
                    Console.WriteLine(result);

                command = Console.ReadLine();
            }
        }

        public CommandCertre()
        {
            this.grid = new Grid();
        }
    }

}
