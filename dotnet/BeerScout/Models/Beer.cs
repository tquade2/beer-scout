using System.ComponentModel;

namespace Capstone.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string ABV { get; set; }
        public int BreweryId { get; set; }
    }
}
