using RecipeBook.Domain.Constants;
using System.Collections.Generic;

namespace RecipeBook.Models
{
    public class IngredientDto : ObservableObject
    {
        private string _name;

        private double _quantity;

        public string Name
        {
            get => this._name;
            set
            {
                this._name = value;
                base.OnPropertyChanged(nameof(Name));
            }
        }

        public double Quantity
        {
            get => this._quantity;
            set
            {
                this._quantity = value;
                base.OnPropertyChanged(nameof(Quantity));
            }
        }

        public List<string> GetValidationMessages()
        {
            List<string> messages = new List<string>();

            if (Name == null || Name.Trim().Length == 0) messages.Add("Name required");
            else if (Name.Length > Lengths.Name) messages.Add("Name too long!");

            if (Quantity <= 0) messages.Add("Quantity invalid!");

            return messages;
        }
    }
}
