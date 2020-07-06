using System;
using System.Collections.Generic;
using RecipeBook.Domain.Models;
using RecipeBook.Models;

namespace RecipeBook.ViewsModels
{
    public class RecipesGridViewModel : ObservableObject
    {
        private List<Recipe> _recipes;

        private long _selectedRecipeId;

        public List<Recipe> Recipes
        {
            get => this._recipes;
            set
            {
                this._recipes = value;
                base.OnPropertyChanged(nameof(Recipes));
            }
        }

        public long SelectedRecipeId
        {
            get => this._selectedRecipeId;
            set
            {
                this._selectedRecipeId = value;
                base.OnPropertyChanged(nameof(SelectedRecipeId));
                this.OnSelectedRecipeIdChanged?.Invoke(value);
            }
        }

        public event Action<long> OnSelectedRecipeIdChanged;
    }
}
