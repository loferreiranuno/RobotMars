using System;
using Web.Domain;

namespace Web.Commands
{
    public abstract class RotateBaseCommand
    {
        public static OrientationType[] orientationInClockDirection = new[]
        {
                OrientationType.North,
                OrientationType.East,
                OrientationType.South,
                OrientationType.West
            };

        protected virtual OrientationType Left(OrientationType orientation)
        {
            var index = IndexOf(orientation);
            return index == 0 ? orientationInClockDirection[orientationInClockDirection.Length - 1] : orientationInClockDirection[index - 1];
        }

        private int IndexOf(OrientationType orientation)
        {
            return Array.IndexOf(orientationInClockDirection, orientation);
        }

        protected virtual OrientationType Right(OrientationType orientation)
        {

            var index = IndexOf(orientation);
            return index == orientationInClockDirection.Length - 1 ? orientationInClockDirection[0] : orientationInClockDirection[index + 1];
        }
    }
}