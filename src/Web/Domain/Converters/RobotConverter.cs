using Web.Domain.Model;
using Web.Infrastructure;

namespace Web.Domain.Converters
{
    public class RobotConverter : IConverter<RobotBase, string>
    {
        public RobotBase Convert(string value)
        {
            var parts = value.Split(' ');
            var xCoordinate = int.Parse(parts[0]);
            var yCoordinate = int.Parse(parts[1]);
            var orientation = parts[2][0].ToOrientationType();
            var position = new Position(xCoordinate, yCoordinate);
            var robot = new RobotBase(position, orientation);
            return robot;
        } 
    }

    public class GridConverter : IConverter<GridBoundaries, string>
    {
        public GridBoundaries Convert(string value)
        {
            var parts = value.Split(' ');
            var xLength = int.Parse(parts[0]);
            var yLength = int.Parse(parts[1]);
            return new GridBoundaries(xLength, yLength);
        }
    }
}