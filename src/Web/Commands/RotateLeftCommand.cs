using Web.Domain.Interfaces;
using Web.Domain.Types; 

namespace Web.Commands
{
    public class RotateLeftCommand : RotateBaseCommand, IRobotCommand
    {
        public InstructionType Instruction => InstructionType.RotateLeft;

        public void Execute(IRobot robot)
        {
            robot.SetOrientation(base.Left(robot.GetOrientation()));
        }
    }
}