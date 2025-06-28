using EmbeddedSpa;

namespace Tests;

public class ContentTypesTests
{
    [Theory]
    [InlineData(".html", "text/html")]
    [InlineData(".js", "application/javascript")]
    [InlineData(".mjs", "application/javascript")]
    [InlineData(".css", "text/css")]
    [InlineData(".svg", "image/svg+xml")]
    [InlineData(".json", "application/json")]
    [InlineData(".map", "application/json")]
    [InlineData(".png", "image/png")]
    [InlineData(".jpg", "image/jpeg")]
    [InlineData(".jpeg", "image/jpeg")]
    [InlineData(".webp", "image/webp")]
    [InlineData(".gif", "image/gif")]
    [InlineData(".ico", "image/x-icon")]
    [InlineData(".bmp", "image/bmp")]
    [InlineData(".tiff", "image/tiff")]
    [InlineData(".woff", "font/woff")]
    [InlineData(".woff2", "font/woff2")]
    [InlineData(".ttf", "font/ttf")]
    [InlineData(".otf", "font/otf")]
    [InlineData(".eot", "application/vnd.ms-fontobject")]
    [InlineData(".mp4", "video/mp4")]
    [InlineData(".webm", "video/webm")]
    [InlineData(".mp3", "audio/mpeg")]
    [InlineData(".ogg", "audio/ogg")]
    [InlineData(".wav", "audio/wav")]
    [InlineData(".pdf", "application/pdf")]
    [InlineData(".txt", "text/plain")]
    [InlineData(".xml", "application/xml")]
    [InlineData(".zip", "application/zip")]
    [InlineData(".ts", "application/typescript")]
    [InlineData(".manifest", "application/manifest+json")]
    [InlineData(".unknown", "application/octet-stream")]
    public void Get_ReturnsCorrectContentType(string extension, string expectedContentType)
    {
        var result = ContentTypes.Get($"file{extension}");
        Assert.Equal(expectedContentType, result);
    }

    [Fact]
    public void Get_WithEmptyString_ReturnsDefaultContentType()
    {
        var result = ContentTypes.Get("");
        Assert.Equal("application/octet-stream", result);
    }

    [Fact]
    public void Get_WithUppercaseExtensions_ReturnsDefaultContentType()
    {
        Assert.Equal("application/octet-stream", ContentTypes.Get("file.HTML"));
        Assert.Equal("application/octet-stream", ContentTypes.Get("file.JS"));
        Assert.Equal("application/octet-stream", ContentTypes.Get("file.CSS"));
    }
}
