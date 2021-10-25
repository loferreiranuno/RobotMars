using System.Collections.Generic;

namespace Web.Domain
{
    public static class OrientationExtensions
    {
        private static Dictionary<char, OrientationType> orientationTypesPerChar =
            new Dictionary<char, OrientationType>()
            {
                ['N'] = OrientationType.North,
                ['S'] = OrientationType.South,
                ['E'] = OrientationType.East,
                ['W'] = OrientationType.West
            };

        private static Dictionary<OrientationType, char> charPerOrientationTypes = orientationTypesPerChar.Reverse();

        public static OrientationType ToOrientationType(this char inner)
        {
            if (orientationTypesPerChar.ContainsKey(inner))
            {
                return orientationTypesPerChar[inner];
            }

            return OrientationType.Unknown;
        }

        public static char ToChar(this OrientationType inner)
        { 
            if (charPerOrientationTypes.ContainsKey(inner))
            {
                return charPerOrientationTypes[inner];
            }
            
            return default(char);
        }
    }
}