using System;
using System.Collections.Generic;
using Prism.Navigation;
using Xamarin.Forms;

namespace Forms.Demo
{
	public partial class LoginPage : ContentPage, INavigationPageOptions
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		public bool ClearNavigationStackOnNavigation
		{
			get
			{
				return true;
			}
		}
	}
}
