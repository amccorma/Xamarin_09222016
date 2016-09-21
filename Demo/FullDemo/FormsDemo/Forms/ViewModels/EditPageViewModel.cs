using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Threading.Tasks;

namespace Forms.Demo
{
	public class EditPageViewModel : Prism.Mvvm.BindableBase,  INavigationAware
    {
        string title;
        string input;
        DateTime entered;
        readonly INavigationService navService;
        readonly IEventAggregator eventMessage;

        public EditPageViewModel(INavigationService navigationService, IEventAggregator ea)
		{
            this.navService = navigationService;
            this.eventMessage = ea;
            this.SaveCommand = new DelegateCommand(async () => await Save());
        }

        public DateTime Entered
        {
            get
            {
                return entered;
            }
            set
            {
                SetProperty(ref entered, value);
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                SetProperty(ref title, value);
            }
        }

        public string Input
        {
            get
            {
                return input;
            }
            set
            {
                SetProperty(ref input, value);
            }
        }

        private Models.NoteModel InData { get; set; }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            this.Title = $"{parameters["title"]}";
            if (this.Title == "Add")
            {
                Entered = DateTime.Now;
            }
            else
            {
                var data = parameters["data"] as Models.NoteModel;
                this.Entered = data.Entered;
                this.Input = data.Text;

                // save data for update
                this.InData = data;
            }
        }

        public DelegateCommand SaveCommand { get; private set; }

        private async Task Save()
        {
            var addop = this.title == "Add";
            if (addop)
            {
                this.eventMessage.GetEvent<Events.UpdateEvent>().Publish(new Models.UpdateModel
                {
                    IsAdd = true,
                    Data = new Models.NoteModel(this.Input, this.Entered)
                });
            }
            else
            {
                this.eventMessage.GetEvent<Events.UpdateEvent>().Publish(new Models.UpdateModel
                {
                    IsAdd = false,
                    ID = this.InData.ID,
                    Data = new Models.NoteModel(this.Input, this.Entered)
                });
            }

            // return to previous view
            await this.navService.GoBackAsync();
        }
    }
}
