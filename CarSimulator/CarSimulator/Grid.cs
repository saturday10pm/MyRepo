using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToyRobot
{
    class Grid
    {
        private Car car;

        // Width of the grid.
        private static int WIDTH = 5;

        // Depth of the grid.
        private static int DEPTH = 5;

        // Regular expression of INIT command.
        private static string INIT_COMMAND_PATTERN = "PLACE\\s+(\\d+),(\\d+),(NORTH|SOUTH|EAST|WEST)";

        public Grid()
        {
            this.car = new Car();
        }

        /**
         * Check if the GPS is in the grid.
         * 
         * @param x
         * @param y
         * @return true: legal, false: illegal.
         */
        public static bool isLegalGPS(int x, int y)
        {
            bool result = false;

            if (x >= 0 && x < WIDTH && y >= 0 && y < DEPTH)
                result = true;

            return result;
        }

        private void initCar(String command)
        {
            
            if (Regex.IsMatch(command, INIT_COMMAND_PATTERN))
            {
                MatchCollection matches = Regex.Matches(command, INIT_COMMAND_PATTERN);

                // Parse the INIT command.
                int x = Int32.Parse(matches[0].Groups[1].Value);
                int y = Int32.Parse(matches[0].Groups[2].Value);
                String facing = matches[0].Groups[3].Value;

                this.car.init(x, y, facing);
            }
        }

        public String executeCommand(String command)
        {
            String output = null;

            command = command.Trim();

            if (command.StartsWith("PLACE "))
                this.initCar(command);
            else if (command.Equals("MOVE"))
                this.car.forward();
            else if (command.Equals("LEFT"))
                this.car.turnLeft();
            else if (command.Equals("RIGHT"))
                this.car.turnRight();
            else if (command.Equals("REPORT"))
                output = this.car.reportCarGPS();

            return output;
        }
    }
}
