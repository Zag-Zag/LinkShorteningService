namespace LinkShorteningService.Extension
{
    public static class ExtensionsHttpRequest
    {
        public static string BaseUrl(this HttpRequest req) =>
            req != default
            ? new UriBuilder(req.Scheme, req.Host.Host, req.Host.Port ?? -1).Uri.AbsoluteUri
            : string.Empty;

        /*public static string BaseUrl(this HttpRequest req)
        {
            if (req == default)
            {
                return string.Empty;
            }
            var uriBuilder = new UriBuilder(req.Scheme, req.Host.Host, req.Host.Port ?? -1);
            //if (uriBuilder.Uri.IsDefaultPort)
            ///{
             //   uriBuilder.Port = -1;
            //}

            return uriBuilder.Uri.AbsoluteUri;
        }*/
    }
}
