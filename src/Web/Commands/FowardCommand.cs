using System;
using System.Collections.Generic;
using Web.Domain;
using Web.Robot.Interfaces;

namespace Web.Commands
{
    public class FowardCommand : IRobotCommand
    {
        private static Dictionary<OrientationType, Func<IRobot, Position>> nextPositionGetters =
            new Dictionary<OrientationType, Func<IRobot, Position>>()
            {
                [OrientationType.North] = (robot)=> {  return new Position(robot.GetPosition().XCoordinate, robot.GetPosition().YCoordinate + 1); },
                [OrientationType.South] = (robot)=> {  return new Position(robot.GetPosition().XCoordinate, robot.GetPosition().YCoordinate - 1); },
                [OrientationType.West] = (robot)=> {  return new Position(robot.GetPosition().XCoordinate - 1, robot.GetPosition().YCoordinate); },
                [OrientationType.East] = (robot)=> {  return new Position(robot.GetPosition().XCoordinate + 1, robot.GetPosition().YCoordinate); },
            };

        public InstructionType Instruction => InstructionType.Foward;

        public void Execute(IRobot robot)
        {
            var getPosition = nextPositionGetters[robot.GetOrientation()];
            var position = getPosition(robot);

            robot.SetPosition(position);
        }
    }
}