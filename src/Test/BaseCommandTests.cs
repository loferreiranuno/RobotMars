using Web.Domain;
using Web.Domain.Converters;
using Web.Domain.Interfaces;
using Web.Domain.Model;
using Web.Domain.Types;

namespace Test
{

    public abstract class BaseCommandTests
        {

            private RobotConverter robotConverter;
            private InstructionConverter instructionConverter;

            public BaseCommandTests()
            {
                robotConverter = new RobotConverter();
                instructionConverter = new InstructionConverter();
            }

            public virtual IRobot BuildRobot(int x, int y, OrientationType orientation)
            {
                var position = new Position(x, y);
                return new RobotBase(position, orientation);
            }

            public virtual IRobot BuildRobot(string raw)
            {
                return robotConverter.Convert(raw);
            }

            public virtual InstructionType[] BuildInstructions(string raw)
            {
                return instructionConverter.Convert(raw);
            }
        }
    }
