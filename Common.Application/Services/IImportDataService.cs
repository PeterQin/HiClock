using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Application.Services
{
    public interface IImportDataService
    {
        List<string> OpenFile(string aFileExtension, string aFileDesc);        
    }
}
