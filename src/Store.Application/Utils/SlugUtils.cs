namespace Store.Application.Utils
{
    public static class SlugUtils
    {
        public static string CreateSlug(string productTitle)
        {
            {
                return productTitle
                    .ToLower()
                    .Replace(" ", "-")
                    .Replace("'", "")
                    .Replace("\"", "")
                    .Replace("/", "");
            }
        }
    }
}
