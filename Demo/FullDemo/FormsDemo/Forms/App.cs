using System;
using Forms.Demo.Interfaces;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Forms.Demo
{
	/// <summary>
	/// docs: https://github.com/PrismLibrary/Prism/tree/master/Documentation/Xamarin.Forms
	/// </summary>
    /// 
	public class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

        public int SharedPrefs { get; private set; }

        protected override void OnInitialized()
		{
            if (Container.Resolve<ISharedPrefs>().Get("user") == "")
            {
                
                NavigationService.NavigateAsync("NavigationPage/LoginPage", animated: false);
            }
            else
            {
                NavigationService.NavigateAsync("NavigationPage/NotesPage", animated: false);
            }
		}

		protected override void RegisterTypes()
		{
            // Container.RegisterTypeForNavigation<MainPage, SomeOtherViewModel>(); //override viewmodel convention

            Container.RegisterTypeForNavigation<NavigationPage>();
			Container.RegisterTypeForNavigation<LoginPage>();
			Container.RegisterTypeForNavigation<NotesPage>();
			Container.RegisterTypeForNavigation<EditPage>();
		}
	}
}
