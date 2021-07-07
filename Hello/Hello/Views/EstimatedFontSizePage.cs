using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Hello.Views
{
    public class EstimatedFontSizePage : ContentPage
    {
        Label label;

        public EstimatedFontSizePage()
        {
            label = new Label();
            Padding = new Thickness(0, DevicePlatform.On(0, 20, 0), 0, 0);
            ContentView contentView = new ContentView
            {
                Content = label
            };

            contentView.SizeChanged += OnContentSizeChanged;
            Content = contentView;
        }

        private void OnContentSizeChanged(object sender, EventArgs e)
        {
            if (!(sender is View view)) return;

            string text = "A default system font with a font size of S " +
                "has a line height of about ({0:F1} * S) and an " +
                "average character width of about ({1:F1} * S). " +
                "On this page, which has a width of {2:F0} and a " +
                "height of {3:F0}, a font size of ?1 should " +
                "comfortably render the ??2 characters in this " +
                "paragraph with ?3 lines and about ?4 characters " +
                "per line. Does it work?";

            double lineHeight = DevicePlatform.On(1.2, 1.2, 1.2);
            double charWidth = .5;

            text = string.Format(text, lineHeight, charWidth, view.Width, view.Height);
            int charCount = text.Length;

            // Because:
            // lineCount: view.Height / (lineHeight * fontSize)
            // charsPerLine: view.Width / (charWidth * fontSize)
            // charCount = lineCount * charsPerLine 
            int fontSize = (int)Math.Sqrt(view.Height * view.Width 
                / (charCount * lineHeight * charWidth));

            int lineCount = (int)(view.Height / (lineHeight * fontSize));
            int charsPerLine = (int)(view.Width / (charWidth * fontSize));

            text = text.Replace("?1", fontSize.ToString());
            text = text.Replace("??2", charCount.ToString());
            text = text.Replace("?3", lineCount.ToString());
            text = text.Replace("?4", charsPerLine.ToString());

            label.FontSize = fontSize;
            label.Text = text;  
        }
    }
}