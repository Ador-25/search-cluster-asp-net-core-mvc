using System.ComponentModel.DataAnnotations;

namespace Search_Cluster.Models
{
    public class Url
    {
        [Key]
        public int UrlId { get; set; }
        public string RootUrl { get; set; }

        public ICollection<UrlCrawlingStrategy>UrlCrawlingStrategies{ get; set; }
    }
}
