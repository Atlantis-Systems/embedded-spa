using System.Reflection;
using EmbeddedSpa;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void MapEmbeddedSpa(this WebApplication app, Assembly assembly, string resourceNamespace)
    {
        app.UseMiddleware<EmbeddedStaticFileMiddleware>(assembly, resourceNamespace);
    }
    
    public static void MapEmbeddedSpaFromAsssemblyOf<T>(this WebApplication app, string postfix)
    {
        var assembly = typeof(T).Assembly;
        var resourceNamespace = typeof(T).Namespace + postfix;
        app.UseMiddleware<EmbeddedStaticFileMiddleware>(assembly, resourceNamespace);
    }
    
    public static void MapEmbeddedSpaFromAsssemblyOf<T>(this WebApplication app)
    {
        var assembly = typeof(T).Assembly;
        var resourceNamespace = typeof(T).Namespace + ".wwwroot";
        app.UseMiddleware<EmbeddedStaticFileMiddleware>(assembly, resourceNamespace);
    }
}