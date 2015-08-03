//
//  HomeViewModel.cs
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
using Cirrious.MvvmCross.ViewModels;

namespace SayNumbers.ViewModels
{

    /// <summary>
    /// The view model for the home screen of the app
    /// </summary>
    public sealed class HomeViewModel : MvxViewModel
    {

        #region Properties

        /// <summary>
        /// Gets the command that binds to the button to start practicing
        /// </summary>
        public MvxCommand StartPracticeCommand
        {
            get { return new MvxCommand(() =>
                ShowViewModel<PracticeViewModel>(new {
                    upperBound = UpperBoundText,
                    lowerBound = LowerBoundText
                })); 
            }
        }

        /// <summary>
        /// Gets / sets the lower bound of the numbers generated in practice
        /// </summary>
        public string LowerBoundText { get; set; }

        /// <summary>
        /// Gets / sets the upper bound of the numbers generated in practice
        /// </summary>
        public string UpperBoundText { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeViewModel()
        {
            LowerBoundText = "0";
            UpperBoundText = "199999999";
        }

        #endregion

    }
}

