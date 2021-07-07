using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hello.Views
{
    public class FitToSizeClockPage : ContentPage
    {
        public FitToSizeClockPage()
        {
            Label clockLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Content = clockLabel;
            SizeChanged += (s, e) =>
            {
                if (this.Width > 0)
                    clockLabel.FontSize = this.Width / 6;
            };

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                clockLabel.Text = DateTime.Now.ToString("h:mm:ss tt");
                return true;
            });
        }
    }
}
