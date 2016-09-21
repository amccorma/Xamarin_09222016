using System;

namespace Forms.Demo.Interfaces
{
	public interface ISharedPrefs
	{
		void Save(string key, string value);

		string Get(string key);
	}
}

