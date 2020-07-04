
using System;
using System.Collections.Generic;

namespace RecipeBook.Domain.Models
{
    public class Recipe
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public DateTime DateAdded { get; set; }

        public string Content { get; set; }

        public User CreatedBy { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }
    }
}
