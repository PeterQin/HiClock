using Common.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Waf.Applications.Services;

namespace HiClock.Application.Services
{
    [Export(typeof(IImportDataService)), Export, PartCreationPolicy(CreationPolicy.Shared)]
    internal class ImportDataService : IImportDataService
    {
        private Lazy<IFileDialogService> FFileSvr;
        [ImportingConstructor]
        public ImportDataService(Lazy<IFileDialogService> aFileSvr)
        {
            FFileSvr = aFileSvr;
        }

        public List<string> OpenFile(string aFileExtension, string aFileDesc)
        {
            List<string> result = new List<string>();
            FileDialogResult selectResult = FileDialogServiceExtensions.ShowOpenFileDialog(FFileSvr.Value, new FileType(aFileDesc, aFileExtension), true);
            if (selectResult.FileNames != null && selectResult.FileNames.Length > 0)
            {
                result.AddRange(selectResult.FileNames);
            }
            return result;
        }
    }
}
