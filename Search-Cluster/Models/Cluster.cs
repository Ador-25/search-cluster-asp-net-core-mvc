﻿using System.ComponentModel.DataAnnotations;

namespace Search_Cluster.Models
{
    public class Cluster
    {
        [Key]
        public int Id { get; set; }
        public string ClusterName { get; set; }

        public string? ClusterDescription { get; set; } = "Not updated";
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Url> Urls { get; set; }
    }
}
