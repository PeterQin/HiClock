using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.Foundation
{
    public static class FileExtension
    {
        public static List<string> GetFiles(string aDirectory, string aSearchPattern)
        {
            List<string> result = new List<string>();

            if (Directory.Exists(aDirectory))
            {
                result.AddRange(Directory.GetFiles(aDirectory, aSearchPattern, SearchOption.AllDirectories));
            }

            return result;
        }
    }
}
