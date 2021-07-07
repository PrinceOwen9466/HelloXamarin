using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hello.Views
{
    public class MetricalBoxView : ContentPage
    {
        public MetricalBoxView()
        {
            Content = new BoxView
            {
                Color = Color.Accent,
                WidthRequest = 64,
                HeightRequest = 160,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
        }
    }
}
