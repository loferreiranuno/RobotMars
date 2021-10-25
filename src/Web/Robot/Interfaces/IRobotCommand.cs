using Web.Domain;

namespace Web.Robot.Interfaces
{
    public interface IRobotCommand
    {
        InstructionType Instruction { get; }
        void Execute(IRobot robot);

    }
}
