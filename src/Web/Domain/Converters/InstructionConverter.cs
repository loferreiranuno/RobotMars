using System.Linq;
using Web.Infrastructure;

namespace Web.Domain.Converters
{
    public class InstructionConverter : IConverter<InstructionType[], string>
    {
        public InstructionType[] Convert(string value)
        {
            var instructions = 
                from instruction in value.ToCharArray()
                select instruction.ToInstructionType();
            return instructions.ToArray();
        }
    }
}