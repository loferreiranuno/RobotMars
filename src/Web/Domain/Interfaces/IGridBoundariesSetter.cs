using Web.Domain;
using Web.Domain.Model;
using Web.Grid.Types;

namespace Web.Domain.Interfaces
{
    public interface IGridBoundariesSetter 
    {
        void SetStatus(Position position, GridStatus status);
    }
}