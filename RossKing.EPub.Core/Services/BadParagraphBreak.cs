// -----------------------------------------------------------------------
// <copyright file="BadParagraphBreak.cs" company="RossKing">
// Copyright (c) 2012, Ross King. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RossKing.EPub.Services
{
    using System.Linq;

    /// <summary>
    /// Checks for bad paragraph breaks.
    /// </summary>
    public class BadParagraphBreak : MergeParagraphs
    {
        /// <summary>
        /// Checks to see if the paragraph ends in a valid sentence ending. 
        /// </summary>
        /// <param name="text">The text to test</param>
        /// <returns><see langword="true"/> if <paramref name="text"/> doesn't end in a valid sentence ending; otherwise <see langword="false"/>.</returns>
        protected override bool CheckForEnd(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            var testChar = text.Last(temp => !char.IsWhiteSpace(temp));
            return testChar != '.' && testChar != '!' && testChar != '?';
        }

        /// <summary>
        /// Checks to see if the paragraph starts with a lower case character. 
        /// </summary>
        /// <param name="text">The text to test</param>
        /// <returns><see langword="true"/> if <paramref name="text"/> starts with a lower case character; otherwise <see langword="false"/>.</returns>
        protected override bool CheckForStart(string text)
        {
            return string.IsNullOrWhiteSpace(text) || char.IsLower(text.First(temp => !char.IsWhiteSpace(temp)));
        }
    }
}
