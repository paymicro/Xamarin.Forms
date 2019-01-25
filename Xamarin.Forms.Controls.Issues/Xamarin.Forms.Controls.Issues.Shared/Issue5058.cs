using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Xamarin.Forms.Controls.Issues
{	
	[Preserve (AllMembers=true)]
	[Issue (IssueTracker.Github, 5058, "Slider Value property does not work correctly with a specific min/max value", PlatformAffected.Android)]
	public class Issue5058 : TestContentPage
	{
		protected override void Init()
		{
			var slider = new Slider
			{
				Minimum = 0,
				Maximum = 999
			};
			slider.Value = 500;

			var label = new Label();
			slider.ValueChanged += (_, e) => label.Text = $"Value: {e.NewValue}";

			Content = new StackLayout {
				Children = {
					slider,
					label,
					new Button
					{
						Text = "Set value to 555.12345",
						Command = new Command(() => slider.Value = 555.12345)
					}
				}
			};
		}

#if UITEST && __ANDROID__
		[Test]
		public void Issue5058Test ()
		{
			RunningApp.Tap ("Set value to 555.12345");
			RunningApp.WaitForElement ("Value: 555.12345");
		}
#endif
	}
}
