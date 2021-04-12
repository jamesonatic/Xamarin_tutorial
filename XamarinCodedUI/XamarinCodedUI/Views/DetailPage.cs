using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinCodedUI
{
    public class DetailPage : ContentPage
    {
        public DetailPage(DetailPageViewModel viewModel)
        {
            BindingContext = viewModel;

            Title = "Note detail";

            BackgroundColor = Color.PowderBlue;

            var textLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            textLabel.SetBinding(Label.TextProperty, nameof(DetailPageViewModel.NoteText));

            var exitButton = new Button
            {
                Text = "back",
                BackgroundColor = Color.SteelBlue,
                TextColor = Color.White,
                FontSize = 20
            };
            exitButton.SetBinding(Button.CommandProperty, nameof(DetailPageViewModel.ExitCommand));

            var stack = new StackLayout
            {
                Margin = new Thickness(20, 40)
            };

            stack.Children.Add(textLabel);
            stack.Children.Add(exitButton);

            Content = stack;
        }
    }
}
