using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.Foundation
{
    public static class Util
    {
        public static bool HasElement(this ICollection source)
        {
            if (source != null && source.Count > 0)
            {
                return true;
            }

            return false;
        }

        public static string GetDataDirectory()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HiClock");
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            return path;

        }
    }
}
