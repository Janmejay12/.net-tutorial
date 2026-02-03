using System.ComponentModel.DataAnnotations;

namespace product_mania.DAL
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
       
        [Required]
        public decimal Price { get; set; }

    }
}
