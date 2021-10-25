using Web.Domain;
using Web.Domain.Types;

namespace Web.Domain.Interfaces
{
    public interface IRobotCommand
    {
        InstructionType Instruction { get; }
        void Execute(IRobot robot);

    }
}
