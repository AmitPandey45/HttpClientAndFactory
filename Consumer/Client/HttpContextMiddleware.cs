namespace Consumer.Client
{
    public class HttpContextMiddleware : DelegatingHandler
    {
        private readonly IHttpContextAccessor accessor;
        private string _ctor;

        public HttpContextMiddleware(IHttpContextAccessor accessor)
        {
            _ctor = Guid.NewGuid().ToString();
            this.accessor = accessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var httpContext = accessor.HttpContext;
            if (httpContext.User == null)
            {

            }

            var method = Guid.NewGuid().ToString();

            request.Headers.Add("Middleware-Ctor", _ctor);
            request.Headers.Add("Middleware-Method", method);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
