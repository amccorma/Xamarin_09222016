using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Demo1")]
[assembly: ExportEffect(typeof(FormsDemo.Droid.TextBoxNoAutoComplete), "NoAutoComplete")]
namespace FormsDemo.Droid
{
	public class TextBoxNoAutoComplete : PlatformEffect
	{
		public TextBoxNoAutoComplete()
		{
		}

		protected override void OnAttached()
		{
			var c = this.Control as EntryEditText;
			c.InputType = Android.Text.InputTypes.TextFlagNoSuggestions;
			c.SetFilters(new[] { new Android.Text.InputFilterAllCaps() });
		}

		protected override void OnDetached()
		{
			
		}
	}
}
