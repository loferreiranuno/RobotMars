using Web.Domain;

namespace Test
{
    public abstract class BaseCommandTests {
        public virtual IRobot BuildRobot(int x, int y, OrientationType orientation)
        {
            return new Robot(x, y, orientation);
        }
    }
}
