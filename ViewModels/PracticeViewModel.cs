//
//  PracticeViewModel.cs
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
using System;

using Cirrious.MvvmCross.ViewModels;
using SayNumbers.Plugins;
using SayNumbers.Services;

namespace SayNumbers.ViewModels
{

    /// <summary>
    /// The view model for the practice view of the app
    /// </summary>
    public sealed class PracticeViewModel : MvxViewModel
    {

        #region Variables

        private readonly ITextToSpeech _speechEngine;
        private readonly INumberConversionService _conversionService;
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        private int _currentProblem;
        private int _upperBound;
        private int _lowerBound;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the command for the "answer" button of the practice section
        /// </summary>
        public MvxCommand AnswerButtonCommand
        {
            get { 
                return new MvxCommand(() =>
                {
                    if(String.IsNullOrEmpty(AnswerText)) {
                        AnswerText = _conversionService.ToEnglish(_currentProblem);
                    } else {
                        AnswerText = String.Empty;
                        NextProblem();
                    }    
                });
            }
        }

        /// <summary>
        /// Gets or sets the current text to solve
        /// </summary>
        public string ProblemText
        {
            get { return _problemText; }
            set {
                _problemText = value;
                RaisePropertyChanged(() => ProblemText);
            }
        }
        private string _problemText;

        /// <summary>
        /// Gets or sets the current answer
        /// </summary>
        public string AnswerText 
        {
            get { return _answerText; }
            set { 
                if(_answerText == value) {
                    return;
                }

                _answerText = value;
                RaisePropertyChanged(() => AnswerText);
                _speechEngine.Speak(value);   
            }
        }
        private string _answerText;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="speechEngine">The speech engine plugin</param>
        /// <param name="conversionService">The service to use for converting numbers</param> 
        public PracticeViewModel(ITextToSpeech speechEngine, INumberConversionService conversionService)
        {
            _speechEngine = speechEngine;  
            _conversionService = conversionService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initialize the model
        /// </summary>
        /// <param name="upperBound">The upper bound on numbers generated</param>
        /// <param name="lowerBound">The lower bound on numbers generated</param>
        public void Init(string upperBound, string lowerBound)
        {
            int u, l;
            _upperBound = Int32.TryParse(upperBound, out u) ? u : 19999999;
            _lowerBound = Int32.TryParse(lowerBound, out l) ? l : 0;
            NextProblem();
        }

        #endregion

        #region Private Methods

        private void NextProblem()
        {
            _currentProblem = _random.Next(_lowerBound, _upperBound + 1);
            ProblemText = _conversionService.ToFormattedNumber(_currentProblem);
        }

        #endregion
        
    }
}

