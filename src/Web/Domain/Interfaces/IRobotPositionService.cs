
using Web.Domain.Model; 

namespace Web.Domain.Interfaces
{
    public interface IRobotPositionService 
    {        
        void SetPosition(IRobot robot, Position position); 
    }
}