using RecipeBook.Domain.Constants;
using System.Collections.Generic;

namespace RecipeBook.Models
{
    public class RecipeDto : ObservableObject
    {
        private string _title;

        private string _content;

        public string Title
        {
            get => this._title;
            set
            {
                this._title = value;
                base.OnPropertyChanged(nameof(Title));
            }
        }

        public string Content
        {
            get => this._content;
            set
            {
                this._content = value;
                base.OnPropertyChanged(nameof(Content));
            }
        }

        public List<string> GetValidationMessages()
        {
            List<string> messages = new List<string>();

            if (Title == null || Title.Trim().Length == 0) messages.Add("Recipe Title required");
            else if (Title.Length > Lengths.Title) messages.Add("Recipe Title too long!");

            if (Content == null || Content.Trim().Length == 0) messages.Add("Content required");
            else if (Content.Length > Lengths.MaxVarchar) messages.Add("Content too long!");

            return messages;
        }
    }
}
