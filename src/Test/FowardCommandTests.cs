using Xunit;
using Web.Commands;
using Web.Domain; 
using Web.Robot.Interfaces;

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
            var position = robot.GetPosition();

            command.Execute(robot); 

            Assert.Equal(-1, position.XCoordinate);
            Assert.Equal(0, position.YCoordinate);
        }
        [Fact]
        public void It_should_move_right()
        { 
            var robot = base.BuildRobot(0, 0, OrientationType.East);
            var position = robot.GetPosition();

            command.Execute(robot); 

            Assert.Equal(1, position.XCoordinate);
            Assert.Equal(0, position.YCoordinate);
        }
        [Fact]
        public void It_should_move_up()
        { 
            var robot = base.BuildRobot(0, 0, OrientationType.North);
            var position = robot.GetPosition();

            command.Execute(robot); 

            Assert.Equal(0, position.XCoordinate);
            Assert.Equal(1, position.YCoordinate);
        }

        [Fact]
        public void It_should_move_down()
        { 
            var robot = base.BuildRobot(0, 0, OrientationType.South);
            var position = robot.GetPosition();

            command.Execute(robot); 

            Assert.Equal(0,  position.XCoordinate);
            Assert.Equal(-1, position.YCoordinate);
        }
         
    }   
}
