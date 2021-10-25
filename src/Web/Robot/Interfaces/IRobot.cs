namespace Web.Robot.Interfaces
{
    public interface IRobot : IRobotGetters, IRobotSetters
    {
        bool IsLost{ get; }
    }
}