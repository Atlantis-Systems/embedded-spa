namespace EmbeddedSpa;

public static class ContentTypes
{
    public static string Get(string path)
    {
        if (path.EndsWith(".wasm")) return "application/wasm";
        if (path.EndsWith(".wasm.br")) return "application/wasm";
        if (path.EndsWith(".wasm.gz")) return "application/wasm";
        if (path.EndsWith(".css.br")) return "text/css";
        if (path.EndsWith(".css.gz")) return "text/css";
        if (path.EndsWith(".html")) return "text/html";
        if (path.EndsWith(".js") || path.EndsWith(".mjs")) return "application/javascript";
        if (path.EndsWith(".css")) return "text/css";
        if (path.EndsWith(".svg")) return "image/svg+xml";
        if (path.EndsWith(".json") || path.EndsWith(".map")) return "application/json";
        if (path.EndsWith(".png")) return "image/png";
        if (path.EndsWith(".jpg") || path.EndsWith(".jpeg")) return "image/jpeg";
        if (path.EndsWith(".webp")) return "image/webp";
        if (path.EndsWith(".gif")) return "image/gif";
        if (path.EndsWith(".ico")) return "image/x-icon";
        if (path.EndsWith(".bmp")) return "image/bmp";
        if (path.EndsWith(".tiff")) return "image/tiff";
        if (path.EndsWith(".woff")) return "font/woff";
        if (path.EndsWith(".woff2")) return "font/woff2";
        if (path.EndsWith(".ttf")) return "font/ttf";
        if (path.EndsWith(".otf")) return "font/otf";
        if (path.EndsWith(".eot")) return "application/vnd.ms-fontobject";
        if (path.EndsWith(".mp4")) return "video/mp4";
        if (path.EndsWith(".webm")) return "video/webm";
        if (path.EndsWith(".mp3")) return "audio/mpeg";
        if (path.EndsWith(".ogg")) return "audio/ogg";
        if (path.EndsWith(".wav")) return "audio/wav";
        if (path.EndsWith(".pdf")) return "application/pdf";
        if (path.EndsWith(".txt")) return "text/plain";
        if (path.EndsWith(".xml")) return "application/xml";
        if (path.EndsWith(".zip")) return "application/zip";
        if (path.EndsWith(".ts")) return "application/typescript";
        if (path.EndsWith(".manifest")) return "application/manifest+json";
        return "application/octet-stream";
    }
}
