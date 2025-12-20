using System.ComponentModel.DataAnnotations;

namespace Backend.API.Models
{
    public class AddProductModel
    {
        [Required]
        [MaxLength(140)]
            public string Name { get; set; }
            public int Type { get; set; }
        public AddProductModel() { }
    }
}
