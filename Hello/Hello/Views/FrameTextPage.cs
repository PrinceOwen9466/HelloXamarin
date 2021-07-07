using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hello.Views
{
    public class FrameTextPage : ContentPage
    {
        public FrameTextPage()
        {
            Padding = new Thickness(20);
            BackgroundColor = Color.Aqua;
            
            Frame frame = new Frame();
            frame.BackgroundColor = Color.Accent;
            frame.BorderColor = Color.Yellow;
            frame.VerticalOptions = LayoutOptions.Center;
            frame.HorizontalOptions = LayoutOptions.Center;

            frame.Content = new Label
            {
                Text = "I've been framed!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };

            Content = frame;
        }
    }
}
