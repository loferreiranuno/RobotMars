namespace Web.Domain.Interfaces
{
    public interface IRobot : IRobotGetters, IRobotSetters
    {
        bool IsLost{ get; }
    }
}