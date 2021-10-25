using System.Collections.Generic;
using Web.Domain.Types;

namespace Web.Domain.Interfaces
{
    public interface IRobotNavigator
    {
        void Run(IGridBoundaries grid, IRobot robot, IEnumerable<InstructionType> instructions);
    }
}