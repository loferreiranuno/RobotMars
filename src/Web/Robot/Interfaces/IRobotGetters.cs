using Web.Domain;

namespace Web.Robot.Interfaces
{
    public interface IRobotGetters {
        Position GetPosition();
        OrientationType GetOrientation();
    }
}