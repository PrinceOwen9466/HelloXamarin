using Hello.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Hello.Views
{
    public class NamedFontSizes : ContentPage
    {
        protected StackLayout MainStack;

        public NamedFontSizes()
        {
            Display();
        }

        public virtual void Display()
        {
            FormattedString formatted = new FormattedString();

            var sizes = ReflectiveExtensions.GetValuesAtRuntime<NamedSize, NamedSize>().ToArray();
            for (int i = 0; i < sizes.Length; i++)
            {
                var size = sizes[i];
                double fontSize = Device.GetNamedSize(size.value, typeof(Label));

                formatted.Spans.Add(new Span
                {
                    Text = $"Named Size = {size.value} ({fontSize:F2})",
                    FontSize = fontSize
                });

                if (i == sizes.Length) continue;

                string newLine = Environment.NewLine + Environment.NewLine;
                formatted.Spans.Add(new Span() { Text = newLine });
            }

            MainStack = new StackLayout();
            MainStack.Children.Add(new Label
            {
                FormattedText = formatted,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            });

            Content = new ScrollView
            {
                Content = MainStack
            };
        }
    }
}
