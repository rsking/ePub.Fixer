// -----------------------------------------------------------------------
// <copyright file="CheckEpubViewModel.cs" company="RossKing">
// Copyright (c) 2012, Ross King. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RossKing.EPub.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.IO;
    using Ionic.Zip;

    /// <summary>
    /// View Model to check ePubs.
    /// </summary>
    [Export]
    public class CheckEpubViewModel
    {
        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the checkers.
        /// </summary>
        [ImportMany]
        public IEnumerable<Services.Contracts.IChecker> Checkers { get; set; }

        /// <summary>
        /// Checks the ePub.
        /// </summary>
        public void Check()
        {
            using (var zip = ZipFile.Read(this.FileName))
            {
                var entries = zip.SelectEntries("*.html", "OEBPS/Text");
                var tempDirectory = Path.GetTempPath();
                var anyUpdated = false;

                foreach (var entry in entries)
                {
                    // copy this to a temp directory
                    entry.Extract(tempDirectory, ExtractExistingFileAction.OverwriteSilently);
                    var file = Path.Combine(tempDirectory, entry.FileName);

                    if (File.Exists(file))
                    {
                        var document = System.Xml.Linq.XDocument.Load(file);

                        var html = document.Element("{http://www.w3.org/1999/xhtml}html");
                        if (html == null)
                        {
                            continue;
                        }

                        var head = html.Element("{http://www.w3.org/1999/xhtml}head");
                        var body = html.Element("{http://www.w3.org/1999/xhtml}body");

                        var updated = false;

                        // check the file
                        foreach (var checker in this.Checkers)
                        {
                            updated |= checker.CheckHead(head);
                            updated |= checker.CheckBody(body);
                        }

                        // Now save it
                        if (updated)
                        {
                            document.Save(file);

                            // write this back to the ePub.
                            zip.UpdateFile(file, Path.GetDirectoryName(entry.FileName));
                        }

                        anyUpdated |= updated;
                    }
                }

                if (anyUpdated)
                {
                    zip.Save();
                }
            }
        }
    }
}
