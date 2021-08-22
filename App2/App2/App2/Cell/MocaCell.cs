using ImageCircle.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2.Cell
{
    public class MocaCell : ViewCell
    {
        public MocaCell()
        {
            var Codigo = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
            };
            Codigo.SetBinding(Label.TextProperty, new Binding("Codigo"));

            var Guerra = new Label
            {
                FontSize = 24,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start,
                Margin = 5
            };
            Guerra.SetBinding(Label.TextProperty, new Binding("Guerra"));

            var Image = new CircleImage
            {
                BorderColor = Color.White,
                BorderThickness = 3,
                HeightRequest = 60,
                WidthRequest = 60,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                Source = "Login"
            };
            Image.SetBinding(Label.TextProperty, new Binding("Image"));

            var line1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { Image, Codigo }
            };

            var line2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { Guerra }
            };

            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    line1, line2
                }
            };

        }

    }
}
