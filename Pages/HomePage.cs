//
//  HomePage.cs
//
//  Author:
//      Jim Borden
//
//  Copyright (c) 2015 Jim Borden, Inc All rights reserved.
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//
using Xamarin.Forms;

namespace SayNumbers.Pages
{
    /// <summary>
    /// The home page of the application, where the user controls the settings and starts
    /// the practice mode
    /// </summary>
    public class HomePage : ContentPage
    {
        
        /// <summary>
        /// Constructor
        /// </summary>
        public HomePage()
        {
            BackgroundImage = "bg.png";
            var masterLayout = new StackLayout { 
                Orientation = StackOrientation.Vertical, 
                Spacing = 10
            };
            
            // Start Button
            var startButton = new Button { Text = "スタート", HorizontalOptions = LayoutOptions.Center };
            masterLayout.Children.Add(startButton);
            
            // Text followed by two auto expanding text areas
            var row = new StackLayout { Orientation = StackOrientation.Horizontal, Spacing = 10, Padding = new Thickness(10, 0, 10, 0) };
            row.Children.Add(new Label { Text = "範囲:" });
            masterLayout.Children.Add(row);
            var grid = new Grid();
            grid.HorizontalOptions = LayoutOptions.FillAndExpand;
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            var lowerBoundField = new Entry();
            var upperBoundField = new Entry();
            grid.Children.Add(lowerBoundField, 0, 0);
            grid.Children.Add(upperBoundField, 1, 0);
            row.Children.Add(grid);
            
            // Data binding
            upperBoundField.SetBinding(Entry.TextProperty, new Binding("UpperBoundText", BindingMode.TwoWay));
            lowerBoundField.SetBinding(Entry.TextProperty, new Binding("LowerBoundText", BindingMode.TwoWay));
            startButton.SetBinding(Button.CommandProperty, new Binding("StartPracticeCommand", BindingMode.OneWay));
            
            Content = masterLayout;
            
        }
    }
}


