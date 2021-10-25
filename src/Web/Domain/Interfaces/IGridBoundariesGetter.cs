using Web.Domain;
using Web.Domain.Model;
using Web.Grid.Types;

namespace Web.Domain.Interfaces
{
    public interface IGridBoundariesGetter 
    {
        GridStatus GetStatus(Position position);
    }
}