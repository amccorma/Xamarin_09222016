using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Forms.Demo;
using Forms.Demo.Interfaces;
using Prism;
using Prism.Unity;
using Microsoft.Practices.Unity;
using FormsDemo.Droid.Services;

namespace FormsDemo.Droid
{
	[Activity(Label = "FormsDemo.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App(new AndroidInitializer()));
		}
	}

	public class AndroidInitializer : IPlatformInitializer
	{
		public void RegisterTypes(IUnityContainer container)
		{
			// lifecycle Unity: http://www.tomdupont.net/2013/12/undestanding-unity-lifetime-managers.html
			container.RegisterType<ISharedPrefs, SharedPrefs>();
		}
	}
}