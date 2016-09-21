using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
#if __ANDROID__
using Xamarin.Forms.Platform.Android;
using Android.Views;
#elif __IOS__
    using Xamarin.Forms.Platform.iOS;
    using UIKit;
    using CoreGraphics;
#endif

namespace SharedDemo
{
    public class App : Application
    {
        private Entry entry1;

        public App()
        {
            var layout1 = new StackLayout();
            layout1.Children.Add(new Xamarin.Forms.Label { Text = "Forms Text Box" });

            entry1 = new Xamarin.Forms.Entry();
            layout1.Children.Add(entry1);
			entry1.ClassId = "text1";

            layout1.Children.Add(new Xamarin.Forms.Label { Text = "Native Text Box" });

#if __ANDROID__
            var nativeTextBox = new Android.Widget.EditText(Forms.Context);
            nativeTextBox.InputType = Android.Text.InputTypes.TextFlagNoSuggestions;
            nativeTextBox.SetBackgroundResource(Shared.Droid.Resource.Drawable.EditBackground);
            layout1.Children.Add(nativeTextBox);

#elif __IOS__
            var nativeTextBox = new UITextField();
            nativeTextBox.AutocorrectionType = UITextAutocorrectionType.No;
            nativeTextBox.BackgroundColor = UIColor.Yellow;
            nativeTextBox.Layer.BorderColor = UIColor.Blue.CGColor;
            nativeTextBox.Layer.BorderWidth = 2;
            layout1.Children.Add(nativeTextBox);
#endif

            layout1.Children.Add(new Xamarin.Forms.Button
            {
                Text = "Test",
                Command = new Xamarin.Forms.Command(async () =>
                {
                    var test = $"Output 1 {nativeTextBox.Text}\r\n Output2 {entry1.Text}";
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("output", test, "OK");
                })
            });
            var page = new ContentPage();
            page.Content = layout1;

            this.MainPage = new NavigationPage(page);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
