using Backend.Core.EntityObjects;

namespace Backend.API.Models
{
    public class AddProductListingModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public AddProductListingModel() { }
    }
}
