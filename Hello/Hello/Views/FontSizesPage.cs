using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Hello.Views
{
    public class FontSizesPage : NamedFontSizes
    {
        public FontSizesPage()
        {
            BackgroundColor = Color.White;
        }

        public override void Display()
        {
            base.Display();

            double resolution = 160;
            MainStack.Children.Add(new BoxView
            {
                Color = Color.Accent,
                HeightRequest = resolution / 80
            });

            int[] ptSizes = { 4, 6, 8, 10, 12 };
            
            foreach (double size in ptSizes)
            {
                double fontSize = resolution * size / 72;
                MainStack.Children.Add(new Label
                {
                    Text = $"Point Size = {size} ({fontSize:F2})",
                    FontSize = fontSize,
                    TextColor = Color.Black
                });
            }
        }
    }
}