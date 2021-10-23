namespace Web.Domain
{

    public class Robot : IRobot
    {
        public Position Position { get; private set; }

        public OrientationType Orientation { get; private set; }

        public Robot(
            int xCoordinate,
            int yCoordinate,
            OrientationType orientation)
        {
            this.Position = new Position(xCoordinate, yCoordinate);
            this.Orientation = orientation;
        }

        public void SetOrientation(OrientationType orientation)
        {
            this.Orientation = orientation;
        }

        public void SetPosition(Position position)
        {
            this.Position = position;
        }
    }
}