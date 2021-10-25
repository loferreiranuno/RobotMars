using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Web.Domain
{
    public class Position : IEqualityComparer<Position>
    {

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Position(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public bool Equals(Position other)
        {
            return this.XCoordinate == other.XCoordinate && this.YCoordinate == other.YCoordinate;
        }

        public bool Equals(Position x, Position y)
        {
            return x.XCoordinate == y.XCoordinate && x.YCoordinate == y.YCoordinate;
        }

        public int GetHashCode([DisallowNull] Position obj)
        {
            int hash = 13;
            hash = (hash * 7) + obj.XCoordinate.GetHashCode();
            hash = (hash * 7) + obj.YCoordinate.GetHashCode(); 
            return hash;
        }

        public override string ToString()
        {
            return $"{XCoordinate} {YCoordinate}";
        }
    }
}