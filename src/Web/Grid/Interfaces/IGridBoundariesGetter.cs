using Web.Domain;
using Web.Grid.Types;

namespace Web.Grid.Interfaces
{
    public interface IGridBoundariesGetter 
    {
        GridStatus GetStatus(Position position);
    }
}