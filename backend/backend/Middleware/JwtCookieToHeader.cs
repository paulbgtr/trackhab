namespace backend.Middleware;

public class JwtCookieToHeader
{
    private readonly RequestDelegate _next;

    public JwtCookieToHeader(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Cookies.ContainsKey("jwt"))
        {
            var token = context.Request.Cookies["jwt"];
            if (!string.IsNullOrEmpty(token)) context.Request.Headers.Append("Authorization", "Bearer " + token);
        }

        await _next(context);
    }
}