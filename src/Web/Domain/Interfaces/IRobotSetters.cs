using Web.Domain.Model;
using Web.Domain.Types;

namespace Web.Domain.Interfaces
{
    public interface IRobotSetters {
        void SetOrientation(OrientationType orientation);
        void SetPosition(Position position); 
    }
}