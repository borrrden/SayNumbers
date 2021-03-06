﻿//
// TextToSpeech.cs
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
using Android.OS;
using Android.Speech.Tts;
using Java.Lang;
using SayNumbers.Plugins;

namespace SayNumbers.Droid.Plugins
{
    
    /// <summary>
    /// Android implementation of the text to speech interface
    /// </summary>
    public class TextToSpeechDroid : Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        
        #region Variables
        
        private TextToSpeech _speechEngine;
        
        #endregion
        
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public TextToSpeechDroid()
        {
            var context = MainActivity.CurrentContext;
            _speechEngine = new TextToSpeech(context, this);
        }
        
        #endregion

        #region ITextToSpeech

        public void Speak(string text)
        {
            if(Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop) {
                _speechEngine.Speak(text, QueueMode.Add, null, null);
            } else {
                _speechEngine.Speak(text, QueueMode.Add, null);
            }
        }

        #endregion

        #region IOnInitListener

        public void OnInit(OperationResult status)
        {

        }

        #endregion

    }
}

