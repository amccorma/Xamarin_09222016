using System;

using Xamarin.Forms;

namespace Forms.Demo
{
	public class EditPage : ContentPage
	{
		public EditPage()
		{
            this.SetBinding(ContentPage.TitleProperty, "Title");
            
            var layout = new StackLayout();
            var entry = new Editor();
            entry.SetBinding(Editor.TextProperty, "Input");
            entry.HeightRequest = 100;
            entry.HorizontalOptions = LayoutOptions.FillAndExpand;

            var date = new DatePicker();
            date.SetBinding(DatePicker.DateProperty, "Entered");

            layout.Children.Add(entry);
            layout.Children.Add(date);

            var button = new Button();
            button.Text = "Save";
            button.SetBinding(Button.CommandProperty, "SaveCommand");

            layout.Children.Add(button);

            this.Content = layout;
           

		}
	}
}

