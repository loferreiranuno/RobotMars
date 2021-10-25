using System.Collections.Concurrent;
using System.Collections.Generic;
using Web.Grid.Interfaces;
using Web.Grid.Types;

namespace Web.Domain
{

    public class GridBoundaries : IGridBoundaries
    {
        private const int LOWER_X = 0;
        private const int LOWER_Y = 0;
        private ConcurrentDictionary<string, GridStatus> allAvailablePositions;

        public GridBoundaries(int xLength, int yLength)
        {
            this.allAvailablePositions = BuildGrid(xLength, yLength);
        }

        public GridStatus GetStatus(Position position)
        {
            if (allAvailablePositions.TryGetValue(position.ToString(), out var status))
            {
                return status;
            }

            return GridStatus.None;
        }

        public void SetStatus(Position position, GridStatus status)
        {
            allAvailablePositions.AddOrUpdate(position.ToString(), p => status, (p,v) => status);
        }

        private ConcurrentDictionary<string, GridStatus> BuildGrid(int xLength, int yLength)
        { 
            var positions = new Dictionary<string, GridStatus>();
            for(var x = LOWER_X ; x <= LOWER_X + xLength; x++)
            {
                for(var y  = LOWER_Y; y <= LOWER_Y + yLength; y++)
                {
                    var position = new Position(x, y);
                    positions.Add(position.ToString(), GridStatus.Enabled);
                }
            }

            return new ConcurrentDictionary<string, GridStatus>(positions);
        }
    }
}