using System.Security.Cryptography.X509Certificates;

namespace LakewoodScoop.Data
{
    public class NewsItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public string Comments { get; set; }
    }
}