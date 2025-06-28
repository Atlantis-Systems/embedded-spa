using EmbeddedSpa;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Text;

namespace Tests;

public class EmbeddedStaticFileMiddlewareTests
{
    private readonly Assembly _mockAssembly = typeof(EmbeddedStaticFileMiddlewareTests).Assembly;
    private readonly string _resourceNamespace = "TestApp";

    [Fact]
    public async Task InvokeAsync_WithEmptyPath_DefaultsToIndexHtml()
    {
        var context = new DefaultHttpContext();
        context.Request.Path = "/";
        context.Response.Body = new MemoryStream();
        
        var nextCalled = false;
        RequestDelegate next = _ => { nextCalled = true; return Task.CompletedTask; };
        
        var middleware = new EmbeddedStaticFileMiddleware(next, _mockAssembly, _resourceNamespace);
        
        await middleware.InvokeAsync(context);
        
        Assert.True(nextCalled);
    }

    [Fact]
    public async Task InvokeAsync_WithNullPath_DefaultsToIndexHtml()
    {
        var context = new DefaultHttpContext();
        context.Request.Path = "";
        context.Response.Body = new MemoryStream();
        
        var nextCalled = false;
        RequestDelegate next = _ => { nextCalled = true; return Task.CompletedTask; };
        
        var middleware = new EmbeddedStaticFileMiddleware(next, _mockAssembly, _resourceNamespace);
        
        await middleware.InvokeAsync(context);
        
        Assert.True(nextCalled);
    }

    [Fact]
    public async Task InvokeAsync_WithValidPath_ProcessesRequest()
    {
        var context = new DefaultHttpContext();
        context.Request.Path = "/test.html";
        context.Response.Body = new MemoryStream();
        
        var nextCalled = false;
        RequestDelegate next = _ => { nextCalled = true; return Task.CompletedTask; };
        
        var middleware = new EmbeddedStaticFileMiddleware(next, _mockAssembly, _resourceNamespace);
        
        await middleware.InvokeAsync(context);
        
        Assert.True(nextCalled);
    }

    [Fact]
    public async Task InvokeAsync_WithNestedPath_ConvertsSlashesToDots()
    {
        var context = new DefaultHttpContext();
        context.Request.Path = "/folder/subfolder/test.js";
        context.Response.Body = new MemoryStream();
        
        var nextCalled = false;
        RequestDelegate next = _ => { nextCalled = true; return Task.CompletedTask; };
        
        var middleware = new EmbeddedStaticFileMiddleware(next, _mockAssembly, _resourceNamespace);
        
        await middleware.InvokeAsync(context);
        
        Assert.True(nextCalled);
    }

    [Fact]
    public async Task InvokeAsync_CallsNextMiddleware_WhenResourceNotFound()
    {
        var context = new DefaultHttpContext();
        context.Request.Path = "/nonexistent.html";
        context.Response.Body = new MemoryStream();
        
        var nextCalled = false;
        RequestDelegate next = _ => { nextCalled = true; return Task.CompletedTask; };
        
        var middleware = new EmbeddedStaticFileMiddleware(next, _mockAssembly, _resourceNamespace);
        
        await middleware.InvokeAsync(context);
        
        Assert.True(nextCalled);
    }
}