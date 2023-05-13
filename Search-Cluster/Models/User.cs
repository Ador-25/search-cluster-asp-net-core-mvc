using System.ComponentModel.DataAnnotations;

namespace Search_Cluster.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string FullName { get; set; }
        public ICollection<Cluster> Clusters { get; set; }
    }
}
