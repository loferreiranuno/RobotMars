using Web.Domain.Interfaces;
using Web.Domain.Model;
using Web.Domain.Types; 

namespace Web.Domain
{
    public class RobotBase : IRobot
    { 
        private Position position;
        private OrientationType orientation;

        public bool IsLost {get; private set;}

        public RobotBase(
            Position position,
            OrientationType orientation)
        {
            this.position = position;
            this.orientation = orientation;
        }

        public void SetOrientation(OrientationType orientation)
        {
            this.orientation = orientation;
        }

        public void SetPosition(Position position)
        {
            this.position = position;
        }
 
        public Position GetPosition()
        {
            return this.position;
        }

        public OrientationType GetOrientation()
        {
            return this.orientation;
        }
    }
}