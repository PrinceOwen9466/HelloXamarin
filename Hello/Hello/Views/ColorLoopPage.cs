using Hello.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Hello.Views
{
    public class ColorLoopPage : ContentPage
    {
        public ColorLoopPage()
        {
            InitializeWithReflection();
        }

        void InitializeWithSimpleReflection()
        {
            StackLayout layout = new StackLayout();

            var fields = typeof(Color)
                .GetRuntimeFields();

            List<Tuple<string, Color>> colors = new List<Tuple<string, Color>>();

            foreach (var field in fields)
            {
                var value = field.GetValue(null);
                if (!(value is Color color)) return;

                var instance = new Tuple<string, Color>(field.Name, color);
                colors.Add(instance);

                layout.Children.Add(new Label
                {
                    Text = instance.Item1,
                    TextColor = instance.Item2,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                });
            }

            Content = layout;
        }

        void InitializeWithReflection()
        {
            StackLayout layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Color.Blue,
                Orientation = StackOrientation.Horizontal
            };

            foreach (var instance in ReflectiveExtensions.GetValuesAtRuntime<Color, Color>())
            {
                layout.Children.Add(CreateColorLabel(instance.value, instance.source.Name));
            }

            Content = new ScrollView()
            {
                Content = layout,
                Background = Brush.Red,
                Orientation = ScrollOrientation.Horizontal
            };
        }

        Label CreateColorLabel(Color color, string name)
        {
            Brush background = new SolidColorBrush(UIExtensions.GetVisibleBackground(color));
            
            return new Label
            {
                Background = background,
                TextColor = color,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = name,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
        }
    }
}
