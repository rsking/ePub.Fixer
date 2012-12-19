// -----------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="RossKing">
// Copyright (c) 2012, Ross King. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RossKing.EPub.Wpf
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods.
    /// </summary>
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Filters a sequence based on the elements not being null.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to filter.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that are not null.</returns>
        public static IEnumerable<TSource> WhereNotNull<TSource>(this IEnumerable<TSource> source)
            where TSource : class 
        {
            return source.Where(obj => obj != null);
        }
    }
}
