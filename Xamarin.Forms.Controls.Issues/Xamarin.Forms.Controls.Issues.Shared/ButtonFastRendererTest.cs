﻿using System;
using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

#if UITEST
using NUnit.Framework;
using Xamarin.UITest;
#endif

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.None, 9999, "Button FastRenderers", PlatformAffected.All)]
	public class ButtonFastRendererTest : TestContentPage
	{
		const string Running = "Running...";
		const string Success = "Success";
		const string Failure = "Failure";
		const string btnId = "btnHello";
		protected override void Init()
		{
			var label = new Label { Text = Running };
			var img = new Image { Source = "cover1.jpg", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
			var btn = new Button { AutomationId = btnId, Text = "hello", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
			btn.Clicked += (sender, e) => { label.Text = Success; };
			var grd = new Grid();
			grd.Children.Add(btn);
			grd.Children.Add(img);
			grd.Children.Add(label);
			Content = grd;
		}

#if UITEST
		[Test]
		public void TestButtonUsingElevation ()
		{
			RunningApp.WaitForElement(Running);
			if (RunningApp.Query(c => c.Marked(btnId)).Length > 0)
				RunningApp.Tap(btnId);
			RunningApp.WaitForNoElement(Success);
		}
#endif
	}
}
