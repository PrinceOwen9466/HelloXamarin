using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Hello.Views
{
    public class BlackCatPage : ContentPage
    {
        public BlackCatPage()
        {
            StackLayout mainStack = new StackLayout();
            StackLayout textStack = new StackLayout
            {
                Padding = new Thickness(5),
                Spacing = 5
            };

            Stream stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("Hello.Texts.TheBlackCat.txt");

            using (stream)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    bool goTitle = false;
                    string line;

                    while (null != (line = reader.ReadLine()))
                    {
                        Label label = new Label
                        {
                            Text = line,
                            TextColor = Color.Black
                        };

                        if (!goTitle)
                        {
                            label.HorizontalOptions = LayoutOptions.Center;
                            label.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                            label.FontAttributes = FontAttributes.Bold;
                            
                            mainStack.Children.Add(label);
                            goTitle = true;
                        }
                        else
                        {
                            textStack.Children.Add(label);
                        }
                    }
                }
            }

            ScrollView scroll = new ScrollView
            {
                Content = textStack,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5, 0)
            };

            mainStack.Children.Add(scroll);
            Content = mainStack;
            BackgroundColor = Color.White;
            Padding = new Thickness(0, 20, 0, 0);
        }
    }
}
