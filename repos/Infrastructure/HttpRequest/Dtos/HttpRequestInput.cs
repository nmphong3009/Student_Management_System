namespace Infrastructure.HttpRequest
{
    public class HttpRequestInput
    {
        public Uri? Uri { get; set; }

        public string? URL { get; set; }

        public string Method { get; set; }

        public string? Token { get; set; }
    }

    public class HttpRequestInput<TEntity>
    {
        public Uri? Uri { get; set; }

        public string URL { get; set; }

        public string Method { get; set; }

        public TEntity Entity { get; set; }

        public string? Token { get; set; }
    }
}
