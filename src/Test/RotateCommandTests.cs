using Xunit;
using Web.Commands;
using Web.Domain; 
using Web.Robot.Interfaces;

namespace Test
{
    public class RotateCommandTests : BaseCommandTests
    {
        public IRobotCommand leftCommand;
        public IRobotCommand rightCommand;

        public RotateCommandTests()
        {
            leftCommand = new RotateLeftCommand();
            rightCommand = new RotateRightCommand();
        }

        [Fact]
        public void It_should_rotate_from_north_to_west()
        { 
            var robot = base.BuildRobot(0, 0, OrientationType.North);
            var orientation = robot.GetOrientation();

            leftCommand.Execute(robot);

            Assert.Equal(OrientationType.West, orientation);
        }
        
        [Fact]
        public void It_should_rotate_from_west_to_north()
        { 
            var robot = base.BuildRobot(0, 0, OrientationType.West);

            rightCommand.Execute(robot);

            var orientation = robot.GetOrientation();
            Assert.Equal(OrientationType.North, orientation);
        }
    }   
}
