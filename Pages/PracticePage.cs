//
//  PracticePage.cs
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
    /// The practice section page
    /// </summary>
    public class PracticePage : ContentPage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PracticePage()
        {
            BackgroundImage = "bg.png";
            var stackLayout = new StackLayout { 
                Orientation = StackOrientation.Vertical, 
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 15 };
            
            // Question
            var problemText = new Label { XAlign = TextAlignment.Center };
            problemText.SetBinding(Label.TextProperty, new Binding("ProblemText", BindingMode.OneWay));
            stackLayout.Children.Add(problemText);
            
            // Answer Button
            var answerButton = new Button { Text = "答え", HorizontalOptions = LayoutOptions.Center };
            answerButton.SetBinding(Button.CommandProperty, new Binding("AnswerButtonCommand", BindingMode.OneWay));
            stackLayout.Children.Add(answerButton);
            
            //Answer Text
            var answerText = new Label { XAlign = TextAlignment.Center };
            answerText.SetBinding(Label.TextProperty, new Binding("AnswerText", BindingMode.OneWay));
            stackLayout.Children.Add(answerText);
            
            Content = stackLayout;
        }
    }
}


