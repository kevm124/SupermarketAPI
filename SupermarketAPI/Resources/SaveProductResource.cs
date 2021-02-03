using System.ComponentModel.DataAnnotations;
using SupermarketAPI.Models;

namespace SupermarketAPI.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public short QuantityInPackage { get; set; }

        [Required]
        public EUnitOfMeasurement unitOfMeasurement { get; set; }

        public int CategoryId { get; set; }
    }
}