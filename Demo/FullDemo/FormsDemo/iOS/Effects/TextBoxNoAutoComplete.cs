using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Demo1")]
[assembly: ExportEffect(typeof(Demo.iOS.Effects.TextBoxNoAutoComplete), "NoAutoComplete")]
namespace Demo.iOS.Effects
{
	public class TextBoxNoAutoComplete : PlatformEffect
	{
		public TextBoxNoAutoComplete()
		{
		}

		protected override void OnAttached()
		{
			
		}

		protected override void OnDetached()
		{
			
		}
	}
}
