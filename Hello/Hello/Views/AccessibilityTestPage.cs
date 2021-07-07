using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hello.Views
{
    public class AccessibilityTestPage : ContentPage
    {
        public AccessibilityTestPage()
        {
            Label testLabel = new Label
            {
                Text = "FontSizes of 20" + Environment.NewLine + "20 characters across",
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Label displayLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            testLabel.SizeChanged += (s, e) =>
            {
                displayLabel.Text = string.Format("{0:F0} \u00D7 {1:F0}", 
                    testLabel.Width, testLabel.Height);
            };

            Content = new StackLayout
            {
                Children =
                {
                    testLabel,
                    displayLabel
                }
            };
        }
    }
}
