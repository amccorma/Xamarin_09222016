using System;
using Forms.Demo.Interfaces;
using Demo.Droid.Device;

[assembly: Xamarin.Forms.Dependency(typeof(StatusMessages))]
namespace Demo.Droid.Device
{
	public class StatusMessages : IStatusMessages
	{
		public StatusMessages()
		{
			Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
			{
				BigTed.BTProgressHUD.ForceiOS6LookAndFeel = true;
			});
		}

		#region IStatusMessages implementation

        public void Show(string message)
        {
			Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
			{
				BigTed.BTProgressHUD.Show(message, -1, BigTed.ProgressHUD.MaskType.Black);
				//XHUD.HUD.Show (message, progress, mask);
			});
		}

		public void Dismiss ()
		{
			Xamarin.Forms.Device.BeginInvokeOnMainThread (() => {
				BigTed.BTProgressHUD.Dismiss();
			});
		}

		public void ShowToast (string message, bool showToastCentered = true, Int32 timeoutMS = 1000)
		{
			Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
			{
				BigTed.BTProgressHUD.ShowToast(message, showToastCentered, timeoutMS);
			});

        }

		#endregion
	}
}

