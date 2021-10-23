using Web.Domain;

namespace Web
{
    public interface IRobotCommand
    {
        void Execute(IRobot robot);
    }
}
