using System;
using Android.Content;
using Android.Preferences;
using Android.App;
using Forms.Demo.Interfaces;

namespace FormsDemo.Droid.Services
{
	public class SharedPrefs : ISharedPrefs
	{
		private static object locker = new object();

		public ISharedPreferences DefaultPrefs
		{
			get
			{
				return PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
			}
		}

		public void Save(string key, string value)
		{
			lock (locker)
			{
				var editor = DefaultPrefs.Edit();
				if (String.IsNullOrEmpty(key) == false)
				{
					editor.PutString(key, value);
					editor.Apply();
				}
			}
		}

		public string Get(string key)
		{
			lock (locker)
			{
				return DefaultPrefs.GetString(key, "");
			}
		}
	}
}

