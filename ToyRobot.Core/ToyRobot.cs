namespace ToyRobot.Core
{
    public class ToyRobots
    {
        private int x;
        private int y;
        private string? direction;
        private const int TableSize = 5;

        public void Place(int newX, int newY, string newDirection)
        {
            // Check if the placement is within the table boundaries
            if (IsValidPosition(newX, newY))
            {
                x = newX;
                y = newY;
                direction = newDirection;
            }
        }

        public void Move()
        {
            // Move the robot one unit forward in the current direction
            if (direction == "NORTH" && y < TableSize - 1)
            {
                y++;
            }
            else if (direction == "SOUTH" && y > 0)
            {
                y--;
            }
            else if (direction == "EAST" && x < TableSize - 1)
            {
                x++;
            }
            else if (direction == "WEST" && x > 0)
            {
                x--;
            }
        }

        public void Left()
        {
            // Rotate the robot 90 degrees to the left
            direction = direction switch
            {
                "NORTH" => "WEST",
                "WEST" => "SOUTH",
                "SOUTH" => "EAST",
                "EAST" => "NORTH",
                _ => direction
            };
        }

        public void Right()
        {
            // Rotate the robot 90 degrees to the right
            direction = direction switch
            {
                "NORTH" => "EAST",
                "EAST" => "SOUTH",
                "SOUTH" => "WEST",
                "WEST" => "NORTH",
                _ => direction
            };
        }

        public string Report()
        {
            // Return the current position and direction of the robot
            return $"{x},{y},{direction}";
        }

        private bool IsValidPosition(int newX, int newY)
        {
            // Check if the new position is within the table boundaries
            return newX >= 0 && newX < TableSize && newY >= 0 && newY < TableSize;
        }
    }

}
