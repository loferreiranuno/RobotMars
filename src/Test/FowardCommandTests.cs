using Xunit;
using Web.Commands;
using Web.Domain;
using Web;

namespace Test
{
    public class FowardCommandTests : BaseCommandTests
    {
        public IRobotCommand command; 

        public FowardCommandTests()
        {
            command = new FowardCommand(); 
        }

        [Fact]
        public void It_should_move_left()
        { 
            var robot = base.BuildRobot(0, 0, OrientationType.West);
            command.Execute(robot); 

            Assert.Equal(-1, robot.Position.XCoordinate);
            Assert.Equal(0, robot.Position.YCoordinate);
        }
        [Fact]
        public void It_should_move_right()
        { 
            var robot = base.BuildRobot(0, 0, OrientationType.East);
            command.Execute(robot); 

            Assert.Equal(1, robot.Position.XCoordinate);
            Assert.Equal(0, robot.Position.YCoordinate);
        }
        [Fact]
        public void It_should_move_up()
        { 
            var robot = base.BuildRobot(0, 0, OrientationType.North);
            command.Execute(robot); 

            Assert.Equal(0, robot.Position.XCoordinate);
            Assert.Equal(1, robot.Position.YCoordinate);
        }

        [Fact]
        public void It_should_move_down()
        { 
            var robot = base.BuildRobot(0, 0, OrientationType.South);
            command.Execute(robot); 

            Assert.Equal(0, robot.Position.XCoordinate);
            Assert.Equal(-1, robot.Position.YCoordinate);
        }
         
    }   
}
