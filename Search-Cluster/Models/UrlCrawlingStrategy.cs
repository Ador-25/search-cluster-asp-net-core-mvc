namespace Search_Cluster.Models
{
    public class UrlCrawlingStrategy
    {
        public int UrlId { get; set; }
        public Url Url { get; set; }

        public string  CrawlingStrategyId { get; set; }
        public CrawlingStrategy CrawlingStrategy { get; set; }
    }
}
