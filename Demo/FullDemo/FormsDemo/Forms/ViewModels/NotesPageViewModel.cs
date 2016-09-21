using Forms.Demo.Events;
using Forms.Demo.Exts;
using Forms.Demo.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace Forms.Demo
{
	public class NotesPageViewModel : Prism.Mvvm.BindableBase, INavigationAware
	{
        readonly INavigationService navService;
        ObservableCollection<NoteModel> notes;
        private bool isFirstLoad = true;

        public NotesPageViewModel(INavigationService navigationService, IEventAggregator ea)
		{
            this.navService = navigationService;
            ea.GetEvent<UpdateEvent>().Subscribe(Handled);
            this.AddCommand = new DelegateCommand(async () => await AddButtonClick());
            this.LogoutCommand = new DelegateCommand(async () =>
            {
                await this.navService.NavigateAsync(new Uri("http://demo/NavigationPage/LoginPage", UriKind.Absolute));
            });
        }

        public ObservableCollection<NoteModel> Items
        {
            get {
                return notes;
            }
            set {
                SetProperty(ref notes, value);
            }
        }


        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand LogoutCommand { get; private set; }

        private void Handled(Models.UpdateModel obj)
        {
            if (obj.IsAdd)
            {
                var temp = this.Items;
                temp.Add(obj.Data);
                this.Items = temp;
            }
            else
            {
                var item = this.Items.FirstOrDefault(x => x.ID == obj.ID);
                item.Text = obj.Data.Text;
                item.Entered = obj.Data.Entered;

            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (isFirstLoad)
            {
                // build notes
                var data = new List<Models.NoteModel>();
                data.Add(new NoteModel("Sample 1", DateTime.Now));
                data.Add(new NoteModel("Sample 2", DateTime.Now.AddDays(-2)));
                data.Add(new NoteModel("Sample 3", DateTime.Now.AddMinutes(-190)));
                this.Items = data.ToObservableCollection();

                isFirstLoad = false;
            }
        }

        public async Task ItemClick(Models.NoteModel obj)
        {
            var p = new NavigationParameters();
            p.Add("title", "Edit");
            p.Add("data", obj);
            await this.navService.NavigateAsync("EditPage", p);
        }

        private async Task AddButtonClick()
        {
            var p = new NavigationParameters();
            p.Add("title", "Add");
            await this.navService.NavigateAsync("EditPage", p);
        }
    }
}
