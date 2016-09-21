using Prism.Navigation;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Forms.Demo
{
	public partial class NotesPage : ContentPage
    {
		public NotesPage()
		{
			InitializeComponent();
		}

        protected internal async void ItemSelected(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var view = this.BindingContext as NotesPageViewModel;
                await view.ItemClick(e.Item as Models.NoteModel);

                // deselect item
                (sender as ListView).SelectedItem = null;
            }
        }
    }
}
