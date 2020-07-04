
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecipeBook.Domain.Constants;

namespace RecipeBook.Domain.Models
{
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [StringLength(Lengths.Name)]
        [Required]
        public string Name { get; set; }

        [Column("quantity")]
        [Required]
        public double Quantity { get; set; }

        [ForeignKey("Recipe")]
        [Column("recipe_id")]
        public long RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
