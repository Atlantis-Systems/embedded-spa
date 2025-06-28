# EmbeddedSpa

A .NET 9 library for serving embedded Single Page Applications (SPAs) directly from assembly resources in ASP.NET Core applications.

## Features

- Serve static files (HTML, CSS, JS, images, fonts, etc.) directly from embedded resources
- Comprehensive content type handling for common web assets
- Lightweight middleware for ASP.NET Core pipeline
- Automatic fallback to `index.html` for SPA routing

## Usage

The library provides middleware to serve embedded static files from assembly resources:

```csharp
app.UseMiddleware<EmbeddedStaticFileMiddleware>(assembly, "YourApp.wwwroot");
```

## Content Types

Supports proper MIME types for:
- Web assets (HTML, CSS, JavaScript)
- Images (PNG, JPEG, SVG, WebP, etc.)
- Fonts (WOFF, WOFF2, TTF, OTF)
- Media files (MP4, MP3, etc.)
- Documents and archives

## Requirements

- .NET 9.0
- ASP.NET Core

## Building

This is a library project that compiles to a .dll for use in other applications.