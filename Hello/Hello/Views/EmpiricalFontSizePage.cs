using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hello.Views
{
    struct FontCalc
    {
        public double FontSize { get; set; }
        public double TextHeight { get; set; }

        public FontCalc(Label label, double fontSize, double containerWidth) : this()
        {
            FontSize = fontSize;
            label.FontSize = fontSize;

            SizeRequest request = label.Measure(containerWidth, Double.PositiveInfinity);
            TextHeight = request.Request.Height;
        }

        public override string ToString()
        {
            return $"{FontSize}pt {TextHeight}px";
        }
    }

    public class EmpiricalFontSizePage : ContentPage
    {
        Label label;

        #region Constructors
        public EmpiricalFontSizePage()
        {
            label = new Label();

            Padding = new Thickness(0, DevicePlatform.On(0, 20, 0), 0, 0);

            ContentView contentView = new ContentView
            {
                Content = label,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            contentView.SizeChanged += ContentSizeChanged;
            Content = contentView;
        }

        private void ContentSizeChanged(object sender, EventArgs e)
        {
            if (!(sender is View view)) return;
            if (view.Width <= 0 || view.Height <= 0) return;

            label.Text = 
                "This is a paragraph of text displayed with " + 
                "a FontSize value of ?? that is empirically " + 
                "calculated in a loop within the SizeChanged " + 
                "handler of the Label's container. " +
                "This technique " + "can be tricky: You don't want to get into " + 
                "an infinite loop by triggering a layout pass " + 
                "with every calculation. Does it work?";

            FontCalc lowerFontCalc = new FontCalc(label, 10, view.Width);
            FontCalc upperFontCalc = new FontCalc(label, 200, view.Width);

            while (upperFontCalc.FontSize - lowerFontCalc.FontSize > 1)
            {
                double fontSize = (upperFontCalc.FontSize - lowerFontCalc.FontSize) / 2;

                FontCalc newFontCalc = new FontCalc(label, fontSize, view.Width);

                if (newFontCalc.TextHeight > view.Height)
                {
                    //if (upperFontCalc.FontSize == newFontCalc.FontSize) break;
                    upperFontCalc = newFontCalc;
                }
                else
                {
                    if (lowerFontCalc.FontSize == newFontCalc.FontSize) break;
                    lowerFontCalc = newFontCalc;
                }
            }

            label.FontSize = lowerFontCalc.FontSize;
            label.Text = label.Text.Replace("??", label.FontSize.ToString("F0"));
        }
        #endregion
    }
}
