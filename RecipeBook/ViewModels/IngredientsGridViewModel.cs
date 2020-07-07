using System;
using System.Collections.Generic;
using System.Linq;
using RecipeBook.Models;

namespace RecipeBook.ViewModels
{
    public class IngredientsGridViewModel : ObservableObject
    {
        private readonly Random _random = new Random();

        private List<IngredientDto> _ingredients;

        private long _selectedIngredientNumberToRemove;

        public List<IngredientDto> Ingredients
        {
            get => this._ingredients;
            set
            {
                this._ingredients = value;
                base.OnPropertyChanged(nameof(Ingredients));
            }
        }

        public long SelectedIngredientNumberToRemove
        {
            get => this._selectedIngredientNumberToRemove;
            set
            {
                this._selectedIngredientNumberToRemove = value;
                base.OnPropertyChanged(nameof(SelectedIngredientNumberToRemove));
                this.RemoveIngredient(value);
            }
        }

        public void AddIngredient(string name, double quantity)
        {
            IngredientDto ingredient = new IngredientDto()
            {
                Name = name,
                Quantity = quantity
            };

            this.AddIngredient(ingredient);
        }

        public void AddIngredient(IngredientDto ingredient)
        {
            ingredient.Number = this._random.Next(Int32.MaxValue);
            this.Ingredients.Add(ingredient);
            this.Ingredients = new List<IngredientDto>(this.Ingredients);
        }

        private void RemoveIngredient(long number)
        {
            this.Ingredients = this.Ingredients.Where(ingredient => ingredient.Number != number).ToList();
        }
    }
}
