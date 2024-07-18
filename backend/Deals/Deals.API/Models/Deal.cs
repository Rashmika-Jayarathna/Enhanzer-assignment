using System.ComponentModel.DataAnnotations;
namespace Deals.API.Models
{
    public class Deal
    {
        [Key]
        public Guid Id { get; set; }
        public int Size { get; set; }

        public string category { get; set; }
        public string Employee { get; set; }
        public string Location { get; set; }
        public string Pipeline { get; set; }
        public string Stage { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;


    }
}
