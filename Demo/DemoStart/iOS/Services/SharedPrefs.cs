using System;
using Forms.Demo.Interfaces;
using Foundation;

namespace psea.IOS.Prefs
{
    public class SharedPrefs : ISharedPrefs
    {
        private static object locker = new object();

        public static NSUserDefaults DefaultPrefs
        {
            get
            {
                return NSUserDefaults.StandardUserDefaults;
            }
        }

        public void Save(string key, string value)
        {
            lock (locker)
            {
                if (String.IsNullOrEmpty(key) == false)
                {
                    DefaultPrefs.SetString(value ?? "", key);
                    DefaultPrefs.Synchronize();
                }
            }
        }

        public string Get(string key)
        {
            lock (locker)
            {
                try
                {
                    return DefaultPrefs.StringForKey(key);
                }
                catch (Exception)
                {
                    return String.Empty;
                }
            }
        }
    }
}

