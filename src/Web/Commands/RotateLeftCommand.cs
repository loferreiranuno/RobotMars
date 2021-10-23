using Web.Domain;

namespace Web.Commands
{
    public class RotateLeftCommand : RotateBaseCommand, IRobotCommand
    {
        public void Execute(IRobot robot)
        {
            robot.SetOrientation(base.Left(robot.Orientation));
        }
    }
}