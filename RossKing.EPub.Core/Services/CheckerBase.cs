// -----------------------------------------------------------------------
// <copyright file="CheckerBase.cs" company="RossKing">
// Copyright (c) 2012, Ross King. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RossKing.EPub.Services
{
    /// <summary>
    /// Base implementation of the <see cref="Contracts.IXmlChecker"/> interface.
    /// </summary>
    public abstract class CheckerBase : Contracts.IXmlChecker
    {
        /// <summary>
        /// Checks the head element.
        /// </summary>
        /// <param name="headElement">The head element</param>
        /// <returns><see langword="true"/> if the head was modified; otherwise <see langword="false"/>.</returns>
        public virtual bool CheckHead(System.Xml.Linq.XElement headElement)
        {
            return false;
        }

        /// <summary>
        /// Checks the body element.
        /// </summary>
        /// <param name="bodyElement">The body element</param>
        /// <returns><see langword="true"/> if the body was modified; otherwise <see langword="false"/>.</returns>
        public virtual bool CheckBody(System.Xml.Linq.XElement bodyElement)
        {
            return false;
        }
    }
}
