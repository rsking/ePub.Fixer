// -----------------------------------------------------------------------
// <copyright file="IChecker.cs" company="RossKing">
// Copyright (c) 2012, Ross King. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RossKing.EPub.Services.Contracts
{
    using System.ComponentModel.Composition;
    using System.Xml.Linq;

    /// <summary>
    /// Interface for checking files.
    /// </summary>
    [InheritedExport]
    public interface IChecker
    {
        /// <summary>
        /// Checks the head element.
        /// </summary>
        /// <param name="headElement">The head element</param>
        /// <returns><see langword="true"/> if the head was modified; otherwise <see langword="false"/>.</returns>
        bool CheckHead(XElement headElement);

        /// <summary>
        /// Checks the body element.
        /// </summary>
        /// <param name="bodyElement">The body element</param>
        /// <returns><see langword="true"/> if the body was modified; otherwise <see langword="false"/>.</returns>
        bool CheckBody(XElement bodyElement);
    }
}
