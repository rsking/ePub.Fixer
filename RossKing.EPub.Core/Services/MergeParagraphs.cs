// -----------------------------------------------------------------------
// <copyright file="MergeParagraphs.cs" company="RossKing">
// Copyright (c) 2012, Ross King. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RossKing.EPub.Services
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Abstract class to merge paragraphs.
    /// </summary>
    public abstract class MergeParagraphs : CheckerBase
    {
        /// <summary>
        /// Checks the body element.
        /// </summary>
        /// <param name="bodyElement">The body element</param>
        /// <returns><see langword="true"/> if the body was modified; otherwise <see langword="false"/>.</returns>
        public override bool CheckBody(XElement bodyElement)
        {
            var edited = false;
            var paragraphName = string.Format("{{{0}}}{1}", bodyElement.Name.NamespaceName, "p");
            var paragraphElements = bodyElement.Elements(paragraphName);
            
            XElement previousParagraph = null;
            var paragraphsToRemove = new List<XElement>();

            foreach (var paragraphElement in paragraphElements)
            {
                // check to see if this has matching quotes.
                var element = paragraphElement;
                var paragraphText = element.Value;

                if (previousParagraph != null)
                {
                    // see if this matches the start criteria
                    if (this.CheckForStart(paragraphText))
                    {
                        edited = true;
                        previousParagraph.Value += ' ';
                        previousParagraph.Value += paragraphText;

                        paragraphsToRemove.Add(element);

                        element = previousParagraph;
                        paragraphText = element.Value;
                    }
                }

                previousParagraph = null;

                if (this.CheckForEnd(paragraphText))
                {
                    previousParagraph = element;
                }
            }

            foreach (var paragraph in paragraphsToRemove)
            {
                paragraph.Remove();
            }

            return edited;
        }

        /// <summary>
        /// Checks for the end criteria.
        /// </summary>
        /// <param name="text">The text to test.</param>
        /// <returns><see langword="true"/> if <paramref name="text"/> fulfils the criteria; otherwise <see langword="false"/>.</returns>
        protected abstract bool CheckForEnd(string text);

        /// <summary>
        /// Checks for the start criteria.
        /// </summary>
        /// <param name="text">The text to test.</param>
        /// <returns><see langword="true"/> if <paramref name="text"/> fulfils the criteria; otherwise <see langword="false"/>.</returns>
        protected abstract bool CheckForStart(string text);
    }
}
