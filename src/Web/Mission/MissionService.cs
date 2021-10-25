using System.Collections.Generic;
using System.Linq;
using System;
using Web.Infrastructure;
using Web.Domain.Interfaces;
using Web.Domain.Types;

namespace Web.Domain
{

    public class MissionService : IMissionService
    {
        private IRobotNavigator navigator;

        private IConverter<RobotBase, string> robotConverter;
        private IConverter<GridBoundaries, string> gridBoundariesConverter;
        private IConverter<InstructionType[], string> instructionsConverter;

        public MissionService(
            IRobotNavigator navigator,
            IConverter<RobotBase, string> robotConverter,
            IConverter<GridBoundaries, string> gridBoundariesConverter,
            IConverter<InstructionType[], string> instructionsConverter)
        {
            this.navigator = navigator;
            this.robotConverter = robotConverter;
            this.gridBoundariesConverter = gridBoundariesConverter;
            this.instructionsConverter = instructionsConverter;
        }

        public MissionResult Execute(string data)
        {
            if(string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException();
            }

            var log = new List<string>();

            var parts = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            var grid = gridBoundariesConverter.Convert(parts[0]);

            var robotAndInstructionsParts = parts.Skip(1);

            var instructionsPerRobot = GetRobotAndInstructions(robotAndInstructionsParts).ToArray();
            foreach (var (robot, instructions) in instructionsPerRobot)
            {
                var isLost = false;
                try
                {
                    navigator.Run(grid, robot, instructions);
                }
                catch (OutOfBoundariesException)
                {
                    isLost = true;
                }

                log.Add(RobotLog(robot, isLost));
            }

            return new MissionResult
            {
                Log = log
            };
        }

        private string RobotLog(IRobot robot, bool isLost)
        {
            var position = robot.GetPosition();
            var orientation = robot.GetOrientation();

            var log = position.ToString() + ' ' + orientation.ToChar();
            return isLost ? log + " LOST" : log;
        }

        private IEnumerable<(IRobot robot1, InstructionType[] instructions)> GetRobotAndInstructions(IEnumerable<string> parts)
        {
            var currentBatch = 0;
            var batchSize = 2;
            while (currentBatch * batchSize < parts.Count())
            {
                string[] lines = parts.Skip(currentBatch * batchSize).Take(batchSize).ToArray();
                var robot = robotConverter.Convert(lines[0]);
                var instructions = instructionsConverter.Convert(lines[1]);

                yield return (robot, instructions);

                currentBatch++;
            }
        }
    }
}