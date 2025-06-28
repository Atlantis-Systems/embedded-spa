using System.Reflection;

namespace EmbeddedSpa;

public class EmbeddedStaticFileMiddleware(RequestDelegate next, Assembly assembly, string resourceNamespace)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value?.TrimStart('/').Replace("/", ".");
        if (string.IsNullOrEmpty(path))
            path = "index.html";
        var resourcePath = $"{resourceNamespace}.{path}";
        var resourceNames = assembly.GetManifestResourceNames();
        var match = resourceNames.FirstOrDefault(r => r.EndsWith(resourcePath, StringComparison.OrdinalIgnoreCase));
        if (match != null)
        {
            var stream = assembly.GetManifestResourceStream(match);
            if (stream != null)
            {
                context.Response.ContentType = ContentTypes.Get(path);
                await stream.CopyToAsync(context.Response.Body);
                return;
            }
        }
        await next(context);
    }
}
