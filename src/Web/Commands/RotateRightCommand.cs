using Web.Domain;

namespace Web.Commands
{
    public class RotateRightCommand : RotateBaseCommand, IRobotCommand
    {
        public void Execute(IRobot robot)
        {
            robot.SetOrientation(base.Right(robot.Orientation));
        }
    }
}