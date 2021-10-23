using System;
using System.Collections.Generic;
using Web.Domain;

namespace Web.Commands
{
    public class FowardCommand : IRobotCommand
    {
        private static Dictionary<OrientationType, Func<IRobot, Position>> nextPositionGetters =
            new Dictionary<OrientationType, Func<IRobot, Position>>()
            {
                [OrientationType.North] = (robot)=> {  return new Position(robot.Position.XCoordinate, robot.Position.YCoordinate + 1); },
                [OrientationType.South] = (robot)=> {  return new Position(robot.Position.XCoordinate, robot.Position.YCoordinate - 1); },
                [OrientationType.West] = (robot)=> {  return new Position(robot.Position.XCoordinate - 1, robot.Position.YCoordinate); },
                [OrientationType.East] = (robot)=> {  return new Position(robot.Position.XCoordinate + 1, robot.Position.YCoordinate); },
            };

        public void Execute(IRobot robot)
        {
            throw new System.NotImplementedException();
        }
    }
}