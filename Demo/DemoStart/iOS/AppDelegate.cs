using Forms.Demo;
using Forms.Demo.Interfaces;
using Foundation;
using Microsoft.Practices.Unity;
using Prism.Unity;
using psea.IOS.Prefs;
using UIKit;

namespace Forms.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }

    //public class iOSInitializer : IPlatformInitializer
    //{
    //    public void RegisterTypes(IUnityContainer container)
    //    {
    //        // lifecycle Unity: http://www.tomdupont.net/2013/12/undestanding-unity-lifetime-managers.html
    //        container.RegisterType<ISharedPrefs, SharedPrefs>();
    //    }
    //}
}

