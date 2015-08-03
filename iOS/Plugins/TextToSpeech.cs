//
//  TextToSpeech.cs
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
using AVFoundation;
using SayNumbers.Plugins;

namespace SayNumbers.iOS.Plugins
{
    
    /// <summary>
    /// An iOS implementation of the ITextToSpeech interface
    /// </summary>
    public sealed class TextToSpeech : ITextToSpeech
    {
        
        #region Variables
        
        private readonly AVSpeechSynthesizer _synthesizer = new AVSpeechSynthesizer();
        
        #endregion

        #region ITextToSpeech

        public void Speak(string text)
        {
            var utterance = new AVSpeechUtterance(text);
            utterance.Rate = AVSpeechUtterance.MinimumSpeechRate + 0.1f;
            utterance.Voice = AVSpeechSynthesisVoice.FromLanguage("en-us");
            _synthesizer.SpeakUtterance(utterance);
        }

        #endregion

    }
}

