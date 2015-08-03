//
//  INumberConversionService.cs
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
namespace SayNumbers.Services
{
    
    /// <summary>
    /// An interface for converting numbers to their text representations
    /// </summary>
    public interface INumberConversionService
    {
        
        /// <summary>
        /// Converts an integer to its English word representation
        /// (e.g. 23 -> Twenty Three)
        /// </summary>
        /// <returns>The English word representation of the integer</returns>
        /// <param name="intValue">The integer to convert</param>
        string ToEnglish(int intValue);

        /// <summary>
        /// Converts a given integer to its Japanese formatted representation
        /// (e.g 543,210 -> 54万3210)
        /// </summary>
        /// <returns>The Japanese formatted number</returns>
        /// <param name="intValue">The integer to convert</param>
        string ToJapanese(int intValue);
        
        /// <summary>
        /// Converts the number to its standard American numeric representation
        /// (i.e. 1,234,567)
        /// </summary>
        /// <returns>The formatted number.</returns>
        /// <param name="intValue">The number to format</param>
        string ToFormattedNumber(int intValue);
        
    }
}

