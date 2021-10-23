using System.Collections.Generic;
using System.Linq;

namespace Web.Domain
{
    public class Mars
    {
        private const int LOWER_X = 0;
        private const int LOWER_Y = 0;
        public IReadOnlyCollection<Position> Positions { get; private set; }

        public Mars(int xLength, int yLength)
        {
            this.Positions = BuildGrid(xLength, yLength);
        }

        private Position[] BuildGrid(int xLength, int yLength)
        {
            var positions =
                from x in Enumerable.Range(LOWER_X, LOWER_X + xLength)
                from y in Enumerable.Range(LOWER_Y, LOWER_X + yLength)
                select new Position(x, y);

            return positions.ToArray();

        }
    }
}