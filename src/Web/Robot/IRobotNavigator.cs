using System.Collections.Generic;
using Web.Grid.Interfaces;
using Web.Robot.Interfaces;

namespace Web.Domain
{
    public interface IRobotNavigator
    {
        void Run(IGridBoundaries grid, IRobot robot, IEnumerable<InstructionType> instructions);
    }
}