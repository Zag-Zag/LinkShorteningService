using Microsoft.AspNetCore.Http;

namespace Servises.Extension;

public static class ExtensionsHttpRequest
{
    public static string BaseUrl(this HttpRequest req) => req != default
        ? new UriBuilder(req.Scheme, req.Host.Host, req.Host.Port ?? -1).Uri.AbsoluteUri
        : string.Empty;
}
