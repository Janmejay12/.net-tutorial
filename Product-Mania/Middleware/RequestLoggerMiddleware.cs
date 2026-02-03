namespace Product_Mania.Middleware
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Request received at {DateTime.Now}");
            await _next(context);
        }
    }
}
