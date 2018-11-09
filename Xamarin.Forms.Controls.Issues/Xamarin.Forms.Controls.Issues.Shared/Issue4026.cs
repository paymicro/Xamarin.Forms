using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;


#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
using Xamarin.Forms.Core.UITests;
#endif

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 4026, "Bindable Span height Issue", PlatformAffected.All)]
#if UITEST
	[NUnit.Framework.Category(UITestCategories.ListView)]
#endif
	public class Issue4026 : TestContentPage
	{
		protected override void Init()
		{
			Title = "Issue4026";
			BindingContext = this;
			var bindingSpan = new Span
			{
				TextColor = Color.Blue
			};
			//bindingSpan.SetBinding(Span.TextProperty, new Binding(nameof(Title), BindingMode.OneWay));
			var ft = new FormattedString();
			ft.Spans.Add(new Span
			{
				Text = "Span Test Span Test Span Test Span Test"
			});
			ft.Spans.Add(bindingSpan);
			var label = new Label
			{
				BackgroundColor = Color.Red,
				BindingContext = this,
				FormattedText = ft
			};
			var moreBtn = new Button
			{
				Text = "Add 'More Text' to span"
			};
			moreBtn.Command = new Command(() => bindingSpan.Text += " More Text");
			Content = new StackLayout
			{
				BackgroundColor = Color.CadetBlue,
				Padding = 10,
				VerticalOptions = LayoutOptions.Start,
				Children =
				{
					moreBtn,
					label
				}
			};
		}

		class SpanModel
		{
			public string Text { get; set; }
		}

#if UITEST
		//[Test]
		//public void ReplaceItemScrollsListToTop()
		//{
		//	RunningApp.WaitForElement(_replaceMe);
		//	RunningApp.Tap(_buttonText);
		//	RunningApp.WaitForElement(_last);
		//}
#endif
	}
}
