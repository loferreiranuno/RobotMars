using Web.Commands;
using Web.Domain;
using Web.Robot.Interfaces;
using Xunit;

namespace Test
{
    public class RobotNavigatorTests: BaseCommandTests 
    {
        public RobotNavigator navigator; 

        public RobotNavigatorTests()
        {
            var commands = new IRobotCommand[] 
            {
                new FowardCommand(),
                new RotateLeftCommand(),
                new RotateRightCommand()
            };

            navigator = new RobotNavigator(commands); 
        }

        [Fact]
        public void It_can_reproduce_case_1_1_E()
        {
            var marsGrid = new GridBoundaries(5, 3);
            
            var robot = base.BuildRobot("1 1 E");
            var instructions = base.BuildInstructions("RFRFRFRF");

            navigator.Run(marsGrid, robot, instructions);

            Assert.Equal(1, robot.GetPosition().XCoordinate);
            Assert.Equal(1, robot.GetPosition().YCoordinate);
            Assert.Equal(OrientationType.East, robot.GetOrientation());
            
        }
        
        [Fact]
        public void It_can_reproduce_case_3_3_N_LOST()
        {
            var marsGrid = new GridBoundaries(5, 3);
            
            var robot = base.BuildRobot("3 2 N");
            var instructions = base.BuildInstructions("FRRFLLFFRRFLL");

            Assert.Throws<OutOfBoundariesException>(()=> navigator.Run(marsGrid, robot, instructions)); 

            Assert.Equal(3, robot.GetPosition().XCoordinate);
            Assert.Equal(3, robot.GetPosition().YCoordinate);
            Assert.Equal(OrientationType.North, robot.GetOrientation());
            
        }

        [Fact]
        public void It_can_reproduce_case_4_2_N()
        {
            var marsGrid = new GridBoundaries(5, 3);
            
            var robot = base.BuildRobot("0 3 W");
            var instructions = base.BuildInstructions("LLFFFRFLFL");

            navigator.Run(marsGrid, robot, instructions);

            Assert.Equal(4, robot.GetPosition().XCoordinate);
            Assert.Equal(2, robot.GetPosition().YCoordinate);
            Assert.Equal(OrientationType.North, robot.GetOrientation());
            
        }
    }
}
