using System.ComponentModel.DataAnnotations;

namespace Final_project.Models
{
    public class Category
    {
        public int CategoryId { get; set; } //PK in the Product will be FK

        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, ErrorMessage = "Name cannot exceed 25 characters")]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Product>? Products { get; set; }  // Navigation property - a category can have many products
    }
}
