namespace HttpServer.Core
{
    public interface IRouter
    {
        HttpResponse Route(HttpRequest request);
    }
}
