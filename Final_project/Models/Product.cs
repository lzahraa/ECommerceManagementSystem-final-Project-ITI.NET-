using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_project.Models
{
    public class Product
    {
        public int ProductId { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string Title { get; set; }


        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        //Range--> from (0.01) : Biggest Positive Double_value in C#.
        // if the user put less Than 0.01(zero)this ErrorMessage will Apear.
        //[Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; } 



        public string? Description { get; set; }



        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        //Range--> from (0) : Biggest Positive integer_value in C#.
        // if the user put less Than 0.01(zero)this ErrorMessage will Apear.
        public int Quantity { get; set; }



        public string? ImagePath { get; set; }

        public int CategoryId { get; set; } //FK
        public Category Category { get; set; }  // Navigation property
    }
}
