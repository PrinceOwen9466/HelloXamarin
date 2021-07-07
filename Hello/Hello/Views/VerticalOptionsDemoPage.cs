using Hello.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Hello.Views
{
    public class VerticalOptionsDemoPage : ContentPage
    {
        public VerticalOptionsDemoPage()
        {
            StackLayout layout = new StackLayout();

            Color[] colors = { Color.Green, Color.Yellow };
            int flipFlopper = 0;

            var positions = ReflectiveExtensions.GetValuesAtRuntime<LayoutOptions, LayoutOptions>()
                .OrderBy(x => x.value.Alignment);

            foreach (var position in positions)
            {
                Label label = new Label
                {
                    Text = $"{nameof(Label.VerticalOptions)} = {position.source.Name}",
                    VerticalOptions = position.value,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    TextColor = colors[flipFlopper],
                    BackgroundColor = colors[flipFlopper = 1 - flipFlopper]
                };

                layout.Children.Add(label);
            }

            //layout.Padding = new Thickness(0, 20, 0, 0);
            Content = layout;
        }
    }
}
