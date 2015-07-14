using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.IO;

namespace Common.Business
{
    public class ShortcutHelper
    {
        private static readonly ShortcutHelper FInstance = new ShortcutHelper();

        public static ShortcutHelper Instance
        {
            get { return ShortcutHelper.FInstance; }
        } 

        private ShortcutHelper()
        {
        }

        public bool CreateShortcutToStartup()
        {
            bool result = true;
            try
            {
                string entryAssembly = System.Reflection.Assembly.GetEntryAssembly().Location;
                string shortcutName = Path.GetFileNameWithoutExtension(entryAssembly) + ".lnk";
                string shortDesc = "Launch " + shortcutName;
                string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                CreateShortcut(entryAssembly, shortcutName, shortDesc, startupFolder);               
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void CreateShortcut(string aLocation, string aShortcutName, string aDescription, string TargetFolder)
        {
            string shotcut = System.IO.Path.Combine(TargetFolder, aShortcutName);
            if (File.Exists(shotcut))
            {
                File.Delete(shotcut);
            }
            IShellLink link = (IShellLink)new ShellLink();

            // setup shortcut information
            link.SetDescription(aDescription);
            link.SetPath(aLocation);

            // save it
            IPersistFile file = (IPersistFile)link;
            file.Save(System.IO.Path.Combine(TargetFolder, aShortcutName), false);
        }

        public void RemoveShortcutFromStartup()
        {
            string entryAssembly = System.Reflection.Assembly.GetEntryAssembly().Location;
            string shortcutName = Path.GetFileNameWithoutExtension(entryAssembly) + ".lnk";
            string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            RemoveShortcut(shortcutName, startupFolder);
        }

        public void RemoveShortcut(string aShortcut, string TargetFolder)
        {
            if (File.Exists(System.IO.Path.Combine(TargetFolder, aShortcut)))
            {
                File.Delete(System.IO.Path.Combine(TargetFolder, aShortcut));
            }
        }
    }

    [ComImport]
    [Guid("00021401-0000-0000-C000-000000000046")]
    internal class ShellLink
    {
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    internal interface IShellLink
    {
        void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out IntPtr pfd, int fFlags);
        void GetIDList(out IntPtr ppidl);
        void SetIDList(IntPtr pidl);
        void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
        void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
        void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
        void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
        void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
        void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
        void GetHotkey(out short pwHotkey);
        void SetHotkey(short wHotkey);
        void GetShowCmd(out int piShowCmd);
        void SetShowCmd(int iShowCmd);
        void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);
        void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
        void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
        void Resolve(IntPtr hwnd, int fFlags);
        void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }
}
