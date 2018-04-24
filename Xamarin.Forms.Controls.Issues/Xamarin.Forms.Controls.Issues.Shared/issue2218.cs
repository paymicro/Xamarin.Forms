using System;
using Xamarin.Forms;
using Xamarin.Forms.CustomAttributes;
using System.Collections.Generic;
using Xamarin.Forms.Internals;
using System.Collections.ObjectModel;

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 2218, "Frame background color does not match the color of other elements", PlatformAffected.iOS)]
	public class issue2218: TestContentPage
	{
		protected override void Init()
		{
			var colors = new List<Color>
			{
				Color.Aqua,
				Color.Black,
				Color.Blue,
				Color.Fuchsia,
				Color.Gray,
				Color.Green,
				Color.Lime,
				Color.Maroon,
				Color.Navy,
				Color.Olive,
				Color.Pink,
				Color.Purple,
				Color.Red,
				Color.Silver,
				Color.Teal,
				Color.White,
				Color.Yellow
			};

			var testListView = new ListView {
				ItemTemplate = new DataTemplate (typeof (_2218CustomViewCell)),
				ItemsSource = colors
			};

			Content = new StackLayout {
				Children = { testListView }
			};
		}

		[Preserve (AllMembers = true)]
		public class _2218CustomViewCell : ViewCell
		{
			public _2218CustomViewCell ()
			{
				var frame = new Frame {
					HasShadow = false,
					Content = new Label {
						Text = "123"
					},
					BackgroundColor = Color.White
				};
				frame.SetBinding (BackgroundColorProperty, ".");

				var grid = new Grid {
					Padding = new Thickness (48, 12)
				};
				grid.SetBinding (BackgroundColorProperty, ".");
				grid.Children.Add (frame);

				View = grid;
			}
		}
	}
}
