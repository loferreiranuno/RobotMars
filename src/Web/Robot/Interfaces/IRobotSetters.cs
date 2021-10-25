using Web.Domain;

namespace Web.Robot.Interfaces
{
    public interface IRobotSetters {
        void SetOrientation(OrientationType orientation);
        void SetPosition(Position position); 
    }
}