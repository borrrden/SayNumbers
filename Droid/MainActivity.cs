//
// MainActivity.cs
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
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Forms.Presenter.Core;
using Cirrious.MvvmCross.Forms.Presenter.Droid;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using SayNumbers.Plugins;
using SayNumbers.Droid.Plugins;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace SayNumbers.Droid
{
    /// <summary>
    /// The main activity for the Android app (sets up MvvmCross and load Xamarin forms)
    /// </summary>
    [Activity(ScreenOrientation=ScreenOrientation.Portrait, Icon="@drawable/ic_launcher")]
    public class MainActivity : FormsApplicationActivity
    {
        
        #region Properties
        
        /// <summary>
        /// Gets the current foreground context (MvvmCross's version doesn't work
        /// well in version 4.0.0-alpha9)
        /// </summary>
        public static Context CurrentContext { get; private set; }
        
        #endregion
        
        #region Overrides
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            Forms.Init(this, savedInstanceState);
            var mvxFormsApp = new MvxFormsApp();
            LoadApplication(mvxFormsApp);

            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsDroidPagePresenter;
            presenter.MvxFormsApp = mvxFormsApp;
            
            Mvx.RegisterType<ITextToSpeech, TextToSpeechDroid>();

            Mvx.Resolve<IMvxAppStart>().Start();
            CurrentContext = this;

        }
        
        #endregion
        
    }
}

