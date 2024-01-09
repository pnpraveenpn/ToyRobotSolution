using ToyRobot.Core;

namespace ToyRobot.WebApi
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [ApiController]
    [Route("api/[controller]")]
    public class ToyRobotController : ControllerBase
    {
        private readonly ToyRobots toyRobot;
        private readonly CommandProcessor commandProcessor;

        public ToyRobotController(ToyRobots robot, CommandProcessor processor)
        {
            toyRobot = robot;
            commandProcessor = processor;
        }

        [HttpPost("commands")]
        public IActionResult ExecuteCommands([FromBody] List<string> commands)
        {
            if (commands == null || commands.Count == 0)
            {
                return BadRequest("Commands cannot be empty");
            }

            commandProcessor.ProcessCommands(commands);
            return Ok(toyRobot.Report());
        }
    }

}
