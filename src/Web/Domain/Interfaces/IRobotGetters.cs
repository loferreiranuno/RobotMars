using Web.Domain.Model;
using Web.Domain.Types;

namespace Web.Domain.Interfaces
{
    public interface IRobotGetters {
        Position GetPosition();
        OrientationType GetOrientation();
    }
}