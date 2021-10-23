namespace Web.Domain
{
    public interface IRobot
    {
        Position Position { get; }
        OrientationType Orientation { get; }
        void SetOrientation(OrientationType orientation);
        void SetPosition(Position position);
    }
}