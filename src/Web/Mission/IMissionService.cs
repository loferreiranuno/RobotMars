namespace Web.Domain
{
    public interface IMissionService
    {
        MissionResult Execute(string data);
    }
}