using AngleSharp.Html.Parser;

namespace LakewoodScoop.Data
{
    public static class NewsClass
    {
        public static List<NewsItem> Scrape()
        {
            var html = GetNewsHtml();
            return ParseHtml(html);
        }
        private static string GetNewsHtml()
        {

            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                UseCookies = true
            };
            using var client = new HttpClient(handler);
            return client.GetStringAsync("https://thelakewoodscoop.com/").Result;
        }
        private static List<NewsItem> ParseHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var divs = document.QuerySelectorAll(".td_module_flex.td_module_flex_5.td_module_wrap.td-animation-stack");
            var items = new List<NewsItem>();
            foreach (var div in divs)
            {
                var item = new NewsItem();
                var title = div.QuerySelector(".entry-title.td-module-title");
                var titleATag = title.QuerySelector("a");
                if (titleATag != null)
                {
                    item.Title = titleATag.TextContent;
                    item.Url = titleATag.Attributes["href"].Value;
                }
                var imageWrapper = div.QuerySelector(".td-image-container");
                if (imageWrapper != null)
                {
                    var aTag = imageWrapper.QuerySelector("a");
                    if (aTag != null)
                    {
                        var span = aTag.QuerySelector("span");
                        if(span!=null)
                        {
                            item.Image = span.Attributes["data-img-url"].Value;
                        }
                    }
                }
                var text = div.QuerySelector(".td-excerpt");
                if (text != null)
                {
                    item.Text = text.TextContent;
                }
                var comments = div.QuerySelector(".td-module-comments");
                if (comments != null)
                {
                    var commentsATag = comments.QuerySelector("a");
                    if (commentsATag != null)
                    {
                        item.Comments = commentsATag.TextContent;
                    }
                }
                items.Add(item);               

            }
            return items;
        }
    }
}