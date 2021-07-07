using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Hello.Views
{
    public class GreetingsPage : ContentPage
    {
        public GreetingsPage()
        {
            //Content = new StackLayout
            //{
            //    Children = {
            //        new Label { Text = "Welcome to Xamarin.Forms!" }
            //    }
            //};

            string os;
#if __ANDROID__
            os = "Android";
#elif __IOS__
            os = "Apple"
#else
            os = "Unknown Operating system";
#endif

            if (Device.RuntimePlatform == Device.Android)
            {
                os += "Platform Android";
            }

            var label = new Label();
            label.Text = $"Welcome to {os}";
            this.Padding = new Thickness(0, 20, 0, 0);
            Content = label;

            var formatted = new FormattedString();
            formatted.Spans.Add(new Span
            {
                Text = "Isn't this",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            formatted.Spans.Add(new Span
            {
                Text = "wonderful",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                ForegroundColor = Color.Red
            });

            StackLayout layout = new StackLayout();

            label.FormattedText = formatted;
            layout.Children.Add(label);
            

            Content = layout;
        }
    }
}