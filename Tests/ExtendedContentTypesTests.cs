using EmbeddedSpa;

namespace Tests;

public class ExtendedContentTypesTests
{
    [Theory]
    [InlineData("app.webp", "image/webp")]
    [InlineData("animation.gif", "image/gif")]
    [InlineData("favicon.ico", "image/x-icon")]
    [InlineData("texture.bmp", "image/bmp")]
    [InlineData("scan.tiff", "image/tiff")]
    public void Get_ImageFormats_ReturnsCorrectContentType(string filename, string expectedContentType)
    {
        var result = ContentTypes.Get(filename);
        Assert.Equal(expectedContentType, result);
    }

    [Theory]
    [InlineData("font.woff", "font/woff")]
    [InlineData("font.woff2", "font/woff2")]
    [InlineData("font.ttf", "font/ttf")]
    [InlineData("font.otf", "font/otf")]
    [InlineData("font.eot", "application/vnd.ms-fontobject")]
    public void Get_FontFormats_ReturnsCorrectContentType(string filename, string expectedContentType)
    {
        var result = ContentTypes.Get(filename);
        Assert.Equal(expectedContentType, result);
    }

    [Theory]
    [InlineData("video.mp4", "video/mp4")]
    [InlineData("video.webm", "video/webm")]
    [InlineData("audio.mp3", "audio/mpeg")]
    [InlineData("audio.ogg", "audio/ogg")]
    [InlineData("sound.wav", "audio/wav")]
    public void Get_MediaFormats_ReturnsCorrectContentType(string filename, string expectedContentType)
    {
        var result = ContentTypes.Get(filename);
        Assert.Equal(expectedContentType, result);
    }

    [Theory]
    [InlineData("document.pdf", "application/pdf")]
    [InlineData("readme.txt", "text/plain")]
    [InlineData("config.xml", "application/xml")]
    [InlineData("archive.zip", "application/zip")]
    public void Get_DocumentFormats_ReturnsCorrectContentType(string filename, string expectedContentType)
    {
        var result = ContentTypes.Get(filename);
        Assert.Equal(expectedContentType, result);
    }

    [Theory]
    [InlineData("module.mjs", "application/javascript")]
    [InlineData("types.ts", "application/typescript")]
    [InlineData("bundle.js.map", "application/json")]
    [InlineData("app.manifest", "application/manifest+json")]
    public void Get_ModernWebFormats_ReturnsCorrectContentType(string filename, string expectedContentType)
    {
        var result = ContentTypes.Get(filename);
        Assert.Equal(expectedContentType, result);
    }

    [Theory]
    [InlineData("path/to/file.webp", "image/webp")]
    [InlineData("assets/fonts/main.woff2", "font/woff2")]
    [InlineData("videos/intro.mp4", "video/mp4")]
    [InlineData("docs/manual.pdf", "application/pdf")]
    [InlineData("src/components/Button.ts", "application/typescript")]
    public void Get_NestedPaths_ReturnsCorrectContentType(string path, string expectedContentType)
    {
        var result = ContentTypes.Get(path);
        Assert.Equal(expectedContentType, result);
    }

    [Theory]
    [InlineData("file.WEBP", "application/octet-stream")]
    [InlineData("file.MP4", "application/octet-stream")]
    [InlineData("file.PDF", "application/octet-stream")]
    [InlineData("file.WOFF2", "application/octet-stream")]
    public void Get_UppercaseExtensions_ReturnsDefaultContentType(string filename, string expectedContentType)
    {
        var result = ContentTypes.Get(filename);
        Assert.Equal(expectedContentType, result);
    }
}