//
//  NumberConversionService.cs
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
using System.Text;

namespace SayNumbers.Services
{
    internal class NumberConversionService : INumberConversionService
    {
        
        #region Constants 

        private static readonly string[] NUMBER_STRINGS = { String.Empty, "One", "Two", "Three", "Four", "Five", 
            "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", 
            "Seventeen", "Eighteen", "Nineteen" };

        private static readonly string[] TENS_STRINGS = { String.Empty, String.Empty, "Twenty", "Thirty", "Forty", 
            "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        private static readonly string[] PLACES_STRINGS = { String.Empty, "Thousand", "Million", "Billion" };

        private static readonly string[] JP_PLACES_STRINGS = { String.Empty, "万", "億" };

        #endregion
        
        #region INumberConversationService
        
        public string ToEnglish(int intValue)
        {
            var sb = new StringBuilder();
            int val = intValue;
            int place = 0;
            while(val > 0) {
                sb.Insert(0, " ");
                sb.Insert(0, PLACES_STRINGS[place++]);
                var remainder = val % 1000;
                var hundredsPlace = remainder / 100;
                var tensPlace = (remainder / 10) % 10;
                var onesPlace = remainder % 10;

                sb.Insert(0, " ");
                if(tensPlace == 1) {
                    sb.Insert(0, NUMBER_STRINGS[10 + onesPlace]);
                } else {
                    sb.Insert(0, NUMBER_STRINGS[onesPlace]);
                    if(!String.IsNullOrEmpty(NUMBER_STRINGS[onesPlace])) {
                        sb.Insert(0, " ");
                    }
                    sb.Insert(0, TENS_STRINGS[tensPlace]);
                }

                if(hundredsPlace > 0) {
                    sb.Insert(0, " Hundred ");
                    sb.Insert(0, NUMBER_STRINGS[hundredsPlace]);
                }

                val /= 1000;
            }

            return sb.ToString().Trim();
        }

        public string ToJapanese(int intValue)
        {
            var sb = new StringBuilder();
            int val = intValue;
            int place = 0;
            while(val > 0) {
                sb.Insert(0, JP_PLACES_STRINGS[place++]);
                var remainder = val % 10000;
                sb.Insert(0, remainder);

                val /= 10000;
            }

            return sb.ToString();
        }

        public string ToFormattedNumber(int intValue)
        {
            var sb = new StringBuilder(intValue.ToString());
            for(int i = sb.Length - 3; i > 0; i -= 3) {
                sb.Insert(i, ',');
            }

            return sb.ToString();
        }
        
        #endregion
        
    }
}

