using System.Collections.Generic;
using System.Linq;
using Web.Domain.Types;

namespace Web.Domain
{
    public static class InstructionExtensions
    {
        private static Dictionary<char, InstructionType> instructionTypesPerChar =
            new Dictionary<char, InstructionType>()
            {
                ['F'] = InstructionType.Foward,
                ['L'] = InstructionType.RotateLeft,
                ['R'] = InstructionType.RotateRight
            };

        private static Dictionary<InstructionType, char> charPerInstructionTypes = instructionTypesPerChar.Reverse();

        public static InstructionType ToInstructionType(this char inner)
        {
            if(instructionTypesPerChar.ContainsKey(inner))
            {
                return instructionTypesPerChar[inner];
            }

            return InstructionType.Unknown;
        }

        public static char ToChar(this InstructionType inner)
        { 
            if (charPerInstructionTypes.ContainsKey(inner))
            {
                return charPerInstructionTypes[inner];
            }
            
            return default(char);
        }
    }
}