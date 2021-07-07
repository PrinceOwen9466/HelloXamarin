using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hello.Views
{
    public class WhatSizePage : ContentPage
    {
        Label label;

        public WhatSizePage()
        {
            label = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            SizeChanged += OnPageSizeChanged;

            Content = label;
        }

        private void OnPageSizeChanged(object sender, EventArgs e)
        {
            label.Text = string.Format($"{Width} \u00D7 {Height}");
        }
    }
}
