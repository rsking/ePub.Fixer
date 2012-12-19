// -----------------------------------------------------------------------
// <copyright file="ShellViewModel.cs" company="RossKing">
// Copyright (c) 2012, Ross King. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RossKing.EPub.Wpf.ViewModels 
{
    using System.ComponentModel.Composition;
    using Models;

    /// <summary>
    /// The shell view model.
    /// </summary>
    [Export(typeof(IShell))]
    public class ShellViewModel : IShell
    {
    }
}