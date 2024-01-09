using System;
using System.Collections.Generic;
using ToyRobot.Core;

class Program
{
    static void Main(string[] args)
    {
        var toyRobots = new ToyRobots();
        var commandProcessor = new CommandProcessor(toyRobots);

        // Example commands
        var commandList = new List<string>
        {
            "PLACE 0,0,NORTH",
            "MOVE",
            "REPORT",
            "PLACE 0,0,NORTH",
            "LEFT",
            "REPORT"
        };

        // Process the commands
        commandProcessor.ProcessCommands(commandList);
    }
}
