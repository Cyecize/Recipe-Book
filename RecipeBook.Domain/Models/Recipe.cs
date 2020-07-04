
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecipeBook.Domain.Constants;

namespace RecipeBook.Domain.Models
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Column("title")]
        [StringLength(Lengths.Title)]
        [Required]
        public string Title { get; set; }

        [Column("date_added")]
        [Required]
        public DateTime DateAdded { get; set; }

        [Column("content")]
        [StringLength(Lengths.MaxVarchar)]
        public string Content { get; set; }

        [ForeignKey("CreatedBy")]
        [Column("created_by_id")]
        public long CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }
    }
}
