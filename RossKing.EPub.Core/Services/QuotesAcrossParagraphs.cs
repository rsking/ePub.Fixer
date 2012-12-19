// -----------------------------------------------------------------------
// <copyright file="QuotesAcrossParagraphs.cs" company="RossKing">
// Copyright (c) 2012, Ross King. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RossKing.EPub.Services
{
    /// <summary>
    /// Checks for quotes across paragraphs.
    /// </summary>
    public class QuotesAcrossParagraphs : MergeParagraphs
    {
        /// <summary>
        /// The opening quote.
        /// </summary>
        private const char OpeningQuote = '“';

        /// <summary>
        /// The closing quote.
        /// </summary>
        private const char ClosingQuote = '”';

        /// <summary>
        /// Checks to see if the paragraph has matching quotes. 
        /// </summary>
        /// <param name="text">The text to test</param>
        /// <returns><see langword="true"/> if <paramref name="text"/> doesn't matching quotes; otherwise <see langword="false"/>.</returns>
        protected override bool CheckForEnd(string text)
        {
            var startIndex = 0;
            int nextIndex;

            while ((nextIndex = text.IndexOf(OpeningQuote, startIndex)) != -1)
            {
                // check the end
                var endIndex = text.IndexOf(ClosingQuote, nextIndex + 1);

                if (endIndex < 0)
                {
                    // we have a start but no end
                    return true;
                }

                startIndex = endIndex + 1;
            }

            return false;
        }

        /// <summary>
        /// Checks to see if the first quote in the paragraph is an end quote. 
        /// </summary>
        /// <param name="text">The text to test</param>
        /// <returns><see langword="true"/> if first quote in <paramref name="text"/> is an end quote; otherwise <see langword="false"/>.</returns>
        protected override bool CheckForStart(string text)
        {
            // see if this has a closing quote first
            var opening = text.IndexOf(OpeningQuote);
            var closing = text.IndexOf(ClosingQuote);

            var merge = false;

            if (opening < 0)
            {
                merge = closing >= 0 || closing < 0;
            }
            else if (closing >= 0)
            {
                merge = closing < opening;
            }

            return merge;
        }
    }
}
