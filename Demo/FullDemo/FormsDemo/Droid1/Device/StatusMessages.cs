using System;

using Forms.Demo.Interfaces;
using AndroidHUD;
using Demo.Droid.Device;

[assembly: Xamarin.Forms.Dependency(typeof(StatusMessages))]
namespace Demo.Droid.Device
{
	public class StatusMessages : Java.Lang.Object, IStatusMessages
	{
        private Android.Content.Context GetContext
        {
            get {
				return Xamarin.Forms.Forms.Context;
			}
        }

		#region IStatusMessages implementation

        public void Show(string message)
        {
           AndroidHUD.AndHUD.Shared.Show(GetContext, message, -1, MaskType.Black, default(TimeSpan), null, true);
		}

		public void Dismiss ()
		{
			Xamarin.Forms.Device.BeginInvokeOnMainThread (() => {
				AndroidHUD.AndHUD.Shared.Dismiss ();
			});
		}

		public void ShowToast (string message, bool showToastCentered = true, Int32 timeoutMS = 1000)
		{
			AndroidHUD.AndHUD.Shared.ShowToast (GetContext, message, AndroidHUD.MaskType.None, new TimeSpan (0, 0, 0, 0, timeoutMS),
				showToastCentered, null, null);

        }

		#endregion
	}
}

