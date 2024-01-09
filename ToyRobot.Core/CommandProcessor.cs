using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Core
{
    public class CommandProcessor
    {
        private ToyRobots toyRobot;

        public CommandProcessor(ToyRobots robot)
        {
            toyRobot = robot;
        }

        public void ProcessCommands(IEnumerable<string> commands)
        {
            foreach (var command in commands)
            {
                // Split the command into components
                var parts = command.Split();

                if (parts.Length > 1)
                {
                    if (parts[0] == "PLACE")
                    {
                        // Process the PLACE command
                        var coordinates = parts[1].Split(',');

                        if (coordinates.Length == 3)
                        {
                            var x = int.Parse(coordinates[0]);
                            var y = int.Parse(coordinates[1]);
                            var direction = coordinates[2];  // Use coordinates[2] instead of parts[2]
                            toyRobot.Place(x, y, direction);
                        }
                    }
                }
                if (toyRobot.Report() != null) // Ignore commands if the robot is not placed
                {
                    if (parts[0] == "MOVE")
                    {
                        toyRobot.Move();
                    }
                    else if (parts[0] == "LEFT")
                    {
                        toyRobot.Left();
                    }
                    else if (parts[0] == "RIGHT")
                    {
                        toyRobot.Right();
                    }
                    else if (parts[0] == "REPORT")
                    {
                        Console.WriteLine(toyRobot.Report());
                    }
                }
            }
        }

    }

}
