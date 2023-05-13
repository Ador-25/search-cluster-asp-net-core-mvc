using System.ComponentModel.DataAnnotations;

namespace Search_Cluster.Models
{
    public class CrawlingStrategy
    {
        [Key]
        public string CrawlingStrategyId { get; set; }
        public string CrawlingStrategyName { get; set; }
        public ICollection<UrlCrawlingStrategy> UrlCrawlingStrategies { get; set; }
    }
}
