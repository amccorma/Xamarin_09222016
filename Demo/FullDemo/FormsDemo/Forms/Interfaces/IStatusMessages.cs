using System;

namespace Forms.Demo.Interfaces
{
	public interface IStatusMessages
	{

		/// <summary>
		/// Show the specified message.
		/// </summary>
		/// <param name="message">Message.</param>
        void Show(string message);

		/// <summary>
		/// Dismiss all Notifications
		/// </summary>
        void Dismiss ();


		/// <summary>
		/// Toast Non Blocking (use Mask Clear)
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="showToastCentered">If set to <c>true</c> show toast centered.</param>
		/// <param name="timeoutMS">Timeout M.</param>
        void ShowToast(string message, bool showToastCentered = true, Int32 timeoutMS = 1000);
	}
}

