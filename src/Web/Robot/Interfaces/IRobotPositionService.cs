using Web.Domain;

namespace Web.Robot.Interfaces
{
    public interface IRobotPositionService 
    {        
        void SetPosition(IRobot robot, Position position); 
    }
}