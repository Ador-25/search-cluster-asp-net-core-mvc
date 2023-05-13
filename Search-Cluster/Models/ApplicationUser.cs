using Microsoft.AspNetCore.Identity;

namespace Search_Cluster.Models
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string Role { get; set; } = "User";
        public ICollection<Cluster> Clusters { get; set; }

        public override int Id { get; set; }
    }
}
