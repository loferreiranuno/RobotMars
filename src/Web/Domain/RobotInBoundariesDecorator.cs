using System;
using Web.Domain.Interfaces;
using Web.Domain.Model;

using Web.Domain.Types;
using Web.Grid.Types; 

namespace Web.Domain
{
    public class RobotBoundariesAwareDecorator : IRobot
    {
        private IRobot inner;
        private Func<Position, GridStatus> getGridStatus;
        private readonly Action<Position> onRobotLost;
        public bool IsLost => inner.IsLost;

        public RobotBoundariesAwareDecorator(
            IRobot inner,  
            Func<Position, GridStatus> getGridStatus,
            Action<Position> onRobotLost)
        {
            this.inner = inner; 
            this.getGridStatus = getGridStatus;
            this.onRobotLost = onRobotLost;
        }

        public OrientationType GetOrientation()
        {
            return inner.GetOrientation();
        }

        public Position GetPosition()
        {
           return inner.GetPosition();
        }

        public void SetOrientation(OrientationType orientation)
        {
           inner.SetOrientation(orientation);
        }

        public void SetPosition(Position position)
        {
            var status = getGridStatus(position);  

            if(status == GridStatus.Enabled)
            {
                inner.SetPosition(position);
                return;
            }

            if(status == GridStatus.None)
            {
                onRobotLost(position);
                return;
            }
    }  }
}