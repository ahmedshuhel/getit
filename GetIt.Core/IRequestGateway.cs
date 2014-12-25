namespace GetIt.Core
{
    public interface IRequestGateway
    {
        Request GetById(int requestId);
    }
}