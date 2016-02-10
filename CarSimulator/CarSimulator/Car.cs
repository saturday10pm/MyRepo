using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    class Car
    {
        private int x;
        private int y;
        private int facing;

        // If the car is initiated.
        private bool initiated = false;


        private void setFacing(String facing)
        {
            if (facing.Equals("EAST"))
                this.facing = 0;
            else if (facing.Equals("SOUTH"))
                this.facing = 1;
            else if (facing.Equals("WEST"))
                this.facing = 2;
            else if (facing.Equals("NORTH"))
                this.facing = 3;
        }

        private String getFacing()
        {
            String facing = "EAST";
            switch (this.facing)
            {
                case 0:
                    facing = "EAST";
                    break;
                case 1:
                    facing = "SOUTH";
                    break;
                case 2:
                    facing = "WEST";
                    break;
                case 3:
                    facing = "NORTH";
                    break;
            }

            return facing;
        }

        public void init(int x, int y, String facing)
        {

            if (Grid.isLegalGPS(this.x, this.y))
            {
                this.x = x;
                this.y = y;
                this.setFacing(facing);
                this.initiated = true;
            }
        }

        public void turnLeft()
        {
            if (this.initiated)
                if (this.facing == 0)
                    this.facing = 3;
                else
                    this.facing--;
        }

        public void turnRight()
        {
            if (this.initiated)
                this.facing = (this.facing + 1) % 4;
        }


        /**
         * Move forward, then if the new location is illegal, move backward.
         */
        public void forward()
        {

            if (this.initiated)
            {

                switch (this.facing)
                {
                    case 0:
                        this.x++;
                        if (!Grid.isLegalGPS(this.x, this.y))
                            this.x--;
                        break;
                    case 1:
                        this.y--;
                        if (!Grid.isLegalGPS(this.x, this.y))
                            this.y++;
                        break;
                    case 2:
                        this.x--;
                        if (!Grid.isLegalGPS(this.x, this.y))
                            this.x++;
                        break;
                    case 3:
                        this.y++;
                        if (!Grid.isLegalGPS(this.x, this.y))
                            this.y--;
                        break;
                }
            }
        }

        public String reportCarGPS()
        {
            String output = null;

            if (this.initiated)
                output = this.x + "," + this.y + "," + this.getFacing();

            return output;
        }
    }
}
