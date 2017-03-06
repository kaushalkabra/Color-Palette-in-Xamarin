using System;
using Xamarin.Forms;

namespace Kabra.Kaushal.PJ1
{
	public class App : Application
	{
		const string redRange = "redRange";
		const string greenRange = "greenRange";
		const string blueRange = "blueRange";

		public App()
		{
			if (Properties.ContainsKey(redRange))
			{
				redSavedValue = (string)Properties[redRange];
			}
			if (Properties.ContainsKey(greenRange))
			{
				greenSavedValue = (string)Properties[greenRange];
			}
			if (Properties.ContainsKey(blueRange))
			{
				blueSavedValue = (string)Properties[blueRange];
			}

			MainPage = new simplePalette();
		}

		public string redSavedValue { set; get; }
		public string greenSavedValue { set; get; }
		public string blueSavedValue { set; get; }

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
			Properties[redRange] = redSavedValue;
			Properties[greenRange] = greenSavedValue;
			Properties[blueRange] = blueSavedValue;
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
