using Web.Domain;
using Web.Grid.Types;

namespace Web.Grid.Interfaces
{
    public interface IGridBoundariesSetter 
    {
        void SetStatus(Position position, GridStatus status);
    }
}