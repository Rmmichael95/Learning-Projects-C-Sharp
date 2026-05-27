namespace HttpServer.Core
{
    /// <summary>
    /// A concrete implementation of your site's specific routing rules.
    /// </summary>
    public class WebAppRouter : IRouter
    {
        public HttpResponse Route(HttpRequest request)
        {
            var response = new HttpResponse();

            // TODO: 1. Evaluate request.Method and request.Path.
            // TODO: 2. If Path == "/", set response.Body to some basic HTML and StatusCode to 200.
            //          Ensure you set response.Headers["Content-Type"] = "text/html".
            // TODO: 3. If Path == "/api/ping", return some JSON and StatusCode 200.
            // TODO: 4. Fallback: Set StatusCode 404, StatusMessage "Not Found", and a basic error body.

            return response;
        }
    }
}
