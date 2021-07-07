using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Hello.Views
{
    public class SizedBoxView : ContentPage
    {
        public SizedBoxView()
        {
            BackgroundColor = Color.Pink;

            Content = new BoxView
            {
                Color = Color.Accent,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                HeightRequest = 100
            };
        }
    }
}