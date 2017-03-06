using System;

using Xamarin.Forms;

namespace Kabra.Kaushal.PJ1
{
	public class simplePalette : ContentPage
	{
		//Declaration of all labels, Buttons, BoxView for showing Color and main stacklayout
		Label redRange, greenRange, blueRange, redLabel, greenLabel, blueLabel;
		Label hexValue, hslValue, hexHeader, hslHeader, boxHeader;
		Button redMinusButton, redPlusButton, greenMinusButton, greenPlusButton, blueMinusButton, bluePlusButton;
		int red = 0, green = 0, blue = 0;
		double hue, saturation, luminosity;
		BoxView colorBox;
		StackLayout stackLayout = new StackLayout();

		public simplePalette()
		{
			//Initialisation of labels and buttons
			Label header = new Label
			{
				Text = "Simple Color Palette",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center
			};
			redLabel = new Label
			{
				Text = "Red Color range",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};
			redMinusButton = new Button
			{
				Text = "-",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			//Assigning event handler method to button on button click
			redMinusButton.Clicked += OnButtonClicked;

			redPlusButton = new Button
			{
				Text = "+",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.StartAndExpand
			};
			redPlusButton.Clicked += OnButtonClicked;

			redRange = new Label
			{
				Text = String.Format("{0}", red),
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			greenLabel = new Label
			{
				Text = "Green Color range",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			greenMinusButton = new Button
			{
				Text = "-",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			greenMinusButton.Clicked += OnButtonClicked;

			greenPlusButton = new Button
			{
				Text = "+",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.StartAndExpand
			};
			greenPlusButton.Clicked += OnButtonClicked;

			greenRange = new Label
			{
				Text = String.Format("{0}", green),
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			blueLabel = new Label
			{
				Text = "Blue Color range",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			blueMinusButton = new Button
			{
				Text = "-",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			blueMinusButton.Clicked += OnButtonClicked;

			bluePlusButton = new Button
			{
				Text = "+",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.StartAndExpand
			};
			bluePlusButton.Clicked += OnButtonClicked;

			blueRange = new Label
			{
				Text = String.Format("{0}", blue),
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			colorBox = new BoxView
			{
				Color = Color.FromRgb(red, green, blue),
				WidthRequest = 150,
				HeightRequest = 100,
				HorizontalOptions = LayoutOptions.Center,
			};

			hexValue = new Label
			{
				Text = "------",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			hslValue = new Label
			{
				Text = "--, --, --",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			boxHeader = new Label
			{
				Text = "Color composition from RGB values",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			hexHeader = new Label
			{
				Text = "RGB composition in Hex Format",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			hslHeader = new Label
			{
				Text = "HSL composition value",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			stackLayout = new StackLayout
			{
				Children =
				  {
					header,
					redLabel,
					//one stacklayout each for one color range
					new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						Children =
						{
							redMinusButton,
							redRange,
							redPlusButton
						}
					},
					greenLabel,
					new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						Children =
						{
							greenMinusButton,
							greenRange,
							greenPlusButton

						}
					},
					blueLabel,
					new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						Children =
						{
							blueMinusButton,
							blueRange,
							bluePlusButton

						}
					},
					boxHeader,
					colorBox,
					hexHeader,
					hexValue,
					hslHeader,
					hslValue,
				   }
			};

			//Adding scrollView to the main stacklayout
			Content = new ScrollView
			{
				Content = stackLayout,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			//Code for loading previously saved data
			App app = Application.Current as App;
			redRange.Text = app.redSavedValue;
			greenRange.Text = app.greenSavedValue;
			blueRange.Text = app.blueSavedValue;

			//Updating red,green,blue values from last saved values
			if (redRange.Text != null && redRange.Text != String.Empty) //&& redRange.Text == "")
			{
				red = int.Parse(redRange.Text);
			}
			else {
				red = 0;
			}
			if (greenRange.Text != null && greenRange.Text != String.Empty)
			{
				green = int.Parse(greenRange.Text);
			}
			else {
				green = 0;
			}
			if (blueRange.Text != null && blueRange.Text != String.Empty)
			{
				blue = int.Parse(blueRange.Text);
			}
			else {
				blue = 0;
			}

			colorBox.Color = Color.FromRgb(red, green, blue);
			hue = colorBox.Color.Hue;
			saturation = colorBox.Color.Saturation;
			luminosity = colorBox.Color.Luminosity;
			hexValue.Text = string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);
			hslValue.Text = string.Format("{0:##.00}, {1:##.00}, {2:##.00}", hue, saturation, luminosity);
		}

		//One event handler for all buttons and boxView, HEX Value and HSL 
		void OnButtonClicked(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			//Getting button and checking value of rgb components not to be less than 0 and greater than 255
			if (button == redMinusButton)
			{
				if (red == 0)
				{
					redMinusButton.IsEnabled = false;
				}
				else {
					red -= 1;
					redRange.Text = String.Format("{0}", red);
				}
			}
			else if (button == redPlusButton)
			{
				if (red == 255)
				{
					redPlusButton.IsEnabled = false;
				}
				else {
					red += 1;
					redRange.Text = String.Format("{0}", red);
				}
			}
			else if (button == greenMinusButton)
			{
				if (green == 0)
				{
					greenMinusButton.IsEnabled = false;
				}
				else {
					green -= 1;
					greenRange.Text = String.Format("{0}", green);
				}
			}
			else if (button == greenPlusButton)
			{
				if (green == 255)
				{
					greenPlusButton.IsEnabled = false;
				}
				else {
					green += 1;
					greenRange.Text = String.Format("{0}", green);
				}
			}
			else if (button == blueMinusButton)
			{
				if (blue == 0)
				{
					blueMinusButton.IsEnabled = false;
				}
				else {
					blue -= 1;
					blueRange.Text = String.Format("{0}", blue);
				}
			}
			else if (button == bluePlusButton)
			{
				if (blue == 255)
				{
					bluePlusButton.IsEnabled = false;
				}
				else {
					blue += 1;
					blueRange.Text = String.Format("{0}", blue);
				}
			}
			//Enabling button again if values are not 0 and 255
			if (red != 0 && red != 255)
			{
				redMinusButton.IsEnabled = true;
				redPlusButton.IsEnabled = true;
			}
			if (green != 0 && green != 255)
			{
				greenMinusButton.IsEnabled = true;
				greenPlusButton.IsEnabled = true;
			}
			if (blue != 0 && blue != 255)
			{
				blueMinusButton.IsEnabled = true;
				bluePlusButton.IsEnabled = true;
			}

			//Assigning 
			colorBox.Color = Color.FromRgb(red, green, blue);
			hue = colorBox.Color.Hue;
			saturation = colorBox.Color.Saturation;
			luminosity = colorBox.Color.Luminosity;
			hexValue.Text = string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);
			hslValue.Text = string.Format("{0:##.00}, {1:##.00}, {2:##.00}", hue, saturation, luminosity);

			//Saving data
			App app = Application.Current as App;
			app.redSavedValue = redRange.Text;
			app.greenSavedValue = greenRange.Text;
			app.blueSavedValue = blueRange.Text;

		}
	}

}
