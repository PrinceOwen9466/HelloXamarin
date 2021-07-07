using Hello.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hello.Views
{
    public class ColorBlocksPage : ContentPage
    {
        public ColorBlocksPage()
        {
            Padding = new Thickness(5);

            StackLayout layout = new StackLayout();
            Content = new ScrollView
            {
                Content = layout
            };


            foreach (var color in ReflectiveExtensions.GetValuesAtRuntime<Color, Color>())
            {
                layout.Children.Add(CreateColorView(color.value, color.source.Name));
            }
        }

        View CreateColorView(Color color, string name)
        {
            string colorCode = string.Format("#{0:X2}{1:X2}{2:X2}", (int)(255 * color.R), (int)(255 * color.G), (int)(255 * color.B));
            string stats = string.Format("{0:F2}, {1:F2}, {2:F2}", color.Hue, color.Saturation, color.Luminosity);

            var background = UIExtensions.GetVisibleBackground(color);
            var foreground = background == Color.Black ? Color.White : Color.Black;

            //Color foreground 


            return new Frame
            {
                BorderColor = Color.Accent,
                Padding = new Thickness(1),
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    BackgroundColor = background,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children =
                    {
                        new BoxView() 
                        { 
                            Color = color, 
                            HorizontalOptions = LayoutOptions.Start, 
                        },
                        new Label
                        {
                            Text = name,
                            TextColor = color,
                            FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                            FontAttributes = FontAttributes.Bold,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start
                        },
                        new StackLayout
                        {
                            HorizontalOptions = LayoutOptions.EndAndExpand,
                            Margin = new Thickness(10),
                            Children =
                            {
                                new Label
                                {
                                    Text = colorCode,
                                    TextColor = color,
                                    VerticalOptions = LayoutOptions.End,
                                    IsVisible = Color.Default != color,
                                },
                                new Label
                                {
                                    Text = stats,
                                    TextColor = color,
                                    VerticalOptions = LayoutOptions.End,
                                    IsVisible = Color.Default != color
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
