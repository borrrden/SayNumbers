//
// Setup.cs
//
// Author:
//       Jim Borden
//
// Copyright (c) 2015 Jim Borden
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
using Cirrious.MvvmCross.Forms.Presenter.Core;
using Cirrious.MvvmCross.Forms.Presenter.Touch;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;
using UIKit;
using Xamarin.Forms;

namespace SayNumbers.iOS
{
    
    /// <summary>
    /// A class used to setup MvvmCross
    /// </summary>
    public class Setup : MvxTouchSetup
    {
        
        #region Constructors
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationDelegate">The mvvmcross application delegate for the app</param>
        /// <param name="window">The window that will be shown.</param>
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }
        
        #endregion
        
        #region Overrides

        protected override IMvxApplication CreateApp()
        {
            return new NumberApplication();
        }

        protected override IMvxTouchViewPresenter CreatePresenter()
        {
            Forms.Init();
            var xamarinFormsApp = new MvxFormsApp();
            return new MvxFormsTouchPagePresenter(Window, xamarinFormsApp);
        }
        
        #endregion
    }
}

