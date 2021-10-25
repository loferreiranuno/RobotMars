using System.Collections.Generic;
using System.Linq; 
using Web.Grid.Types;
using System;
using Web.Domain.Interfaces;
using Web.Domain.Types;
using Web.Domain.Model;

namespace Web.Domain
{

    public class RobotNavigator : IRobotNavigator
    {
        private IEnumerable<IRobotCommand> commands;

        private Func<IRobot, IGridBoundaries, IRobot> buildRobotAwareOfBoundaries = (robot, grid) => new RobotBoundariesAwareDecorator(robot, GetGridStatus(grid), OnRobotOutOfGrid(grid));

        public RobotNavigator(IEnumerable<IRobotCommand> commands)
        {
            this.commands = commands;
        }

        public void Run(
            IGridBoundaries grid,
            IRobot robot,
            IEnumerable<InstructionType> instructions)
        {
            var commands = GetCommandsToBeExecuted(instructions);
            var robotIn = buildRobotAwareOfBoundaries(robot, grid);
            foreach (var command in commands)
            {
                command.Execute(robotIn);
            }
        }

        private IEnumerable<IRobotCommand> GetCommandsToBeExecuted(IEnumerable<InstructionType> instructions)
        {
            return from instruction in instructions
                   from command in GetCommand(instruction)
                   select command;
        }

        private static Action<Position> OnRobotOutOfGrid(IGridBoundaries grid)
        {
            return (position) =>
            { 
                grid.SetStatus(position, GridStatus.Disabled);
                throw new OutOfBoundariesException();
            };
        }

        private static Func<Position, GridStatus> GetGridStatus(IGridBoundaries grid)
        {
            return (position) => grid.GetStatus(position);
        }

        private IEnumerable<IRobotCommand> GetCommand(InstructionType instruction)
        {
            return commands.Where(t => t.Instruction == instruction);
        }
    }
}