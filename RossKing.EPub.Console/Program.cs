// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="RossKing">
// Copyright (c) 2012, Ross King. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RossKing.EPub.Console
{
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.IO;
    using CLAP;
    using CLAP.Interception;

    /// <summary>
    /// Main entry point.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The MEF container.
        /// </summary>
        private CompositionContainer container;

        /// <summary>
        /// The main entry point.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            Parser.RunConsole(args, new Program());
        }

        /// <summary>
        /// Checks the ePub.
        /// </summary>
        [Verb(IsDefault = true)]
        private void Check()
        {
            var checker = this.container.GetExport<ViewModels.CheckEpubViewModel>();

            if (checker == null)
            {
                throw new CompositionException("Failed to compose the CheckEpubViewModel");
            }

            var checkerInstance = checker.Value;
            checkerInstance.FileName = "C:\\Temp\\Dragons of Autumn Twilight - Margaret Weis.epub";
            checkerInstance.Check();
        }

        /// <summary>
        /// Initialises MEF.
        /// </summary>
        /// <param name="context">The verb context</param>
        [PreVerbExecution]
        private void InitialiseMef(PreVerbExecutionContext context)
        {
            // get the current assembly
            var assembly = typeof(Program).Assembly;
            var directory = Path.GetDirectoryName(assembly.Location) ?? Directory.GetCurrentDirectory();

            // An aggregate catalogue that combines multiple catalogues
            this.container =
                new CompositionContainer(
                    new AggregateCatalog(new AssemblyCatalog(assembly), new DirectoryCatalog(directory)));
        }
    }
}
