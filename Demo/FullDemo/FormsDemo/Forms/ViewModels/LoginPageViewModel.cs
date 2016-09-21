using System;
using System.Threading.Tasks;
using Forms.Demo.Interfaces;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace Forms.Demo
{
	public class LoginPageViewModel : BindableBase
	{
        readonly INavigationService navService;
        readonly ISharedPrefs sharedSettings;
        readonly IPageDialogService pageDialogService;
        string username;

        bool canLogin = true;

		public LoginPageViewModel(INavigationService navigationService, ISharedPrefs sharedPrefs, IPageDialogService dialogService)
		{
            this.pageDialogService = dialogService;
            this.navService = navigationService;
			this.sharedSettings = sharedPrefs;
			LoginCommand = new DelegateCommand(async () => await DoLogin()).ObservesCanExecute((x) => CanLogin);

            // reset login
            this.sharedSettings.Save("user", "");
        }

        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                SetProperty(ref username, value);
            }
        }

        public bool CanLogin
		{
			get
			{
				return canLogin;
			}
			set
			{
				SetProperty(ref canLogin, value);
			}
		}

		[Dependency]
		public IStatusMessages StatusMessageService
		{
			get;set;
		}

		public DelegateCommand LoginCommand { get; private set; }

		private async Task DoLogin()
		{
			if (CanLogin)
			{
				CanLogin = false;
                if (String.IsNullOrEmpty(UserName))
                {
                    await this.pageDialogService.DisplayAlertAsync("Login", "Enter a username", "OK");
                    CanLogin = true;
                }
                else
                {
                    // save username
                    this.sharedSettings.Save("user", this.UserName);

                    // do login process
                    StatusMessageService.Show("Please wait");
                    await Task.Delay(1000);
                    StatusMessageService.Dismiss();

                    await this.navService.NavigateAsync(new Uri("http://demo/NavigationPage/NotesPage", UriKind.Absolute));
                    CanLogin = true;
                }
			}
		}
	}
}
