using System.Linq;
using Web.Commands;
using Web.Domain;
using Web.Domain.Converters;
using Web.Domain.Interfaces;
using Xunit;

namespace Test
{
    public class MissionServiceTest : BaseCommandTests
    {
        private MissionService sut;
        private IRobotNavigator robotNavigator;

        public MissionServiceTest()
        {

            robotNavigator = new RobotNavigator(
                new IRobotCommand[]
                {
                    new FowardCommand(),
                    new RotateLeftCommand(),
                    new RotateRightCommand()
                });

            sut = new MissionService(robotNavigator, new RobotConverter(), new GridConverter(), new InstructionConverter());
        }

        [Fact]
        public void it_can_reproduce_input_example()
        {
            var raw = @"5 3 
1 1 E 
RFRFRFRF 
3 2 N 
FRRFLLFFRRFLL 
0 3 W 
LLFFFRFLFL";

            var result = sut.Execute(raw);
            var logs = result.Log.ToArray();

            Assert.Equal(3, logs.Count());
            Assert.Equal("1 1 E", logs[0]);
            Assert.Equal("3 3 N LOST", logs[1]);
            Assert.Equal("4 2 N", logs[2]);

            
        } 
    }
}
