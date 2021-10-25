using Web.Domain;
using Web.Robot.Interfaces;

namespace Web.Commands
{
    public class RotateRightCommand : RotateBaseCommand, IRobotCommand
    {
        public InstructionType Instruction => InstructionType.RotateRight;

        public void Execute(IRobot robot)
        {
            robot.SetOrientation(base.Right(robot.GetOrientation()));
        }
    }
}