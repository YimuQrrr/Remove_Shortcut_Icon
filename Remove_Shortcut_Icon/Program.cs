using System;
using Microsoft.Win32;
using System.Diagnostics;
using System.Security.Principal;

namespace Remove_Shortcut_Icon
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons";
            string Name = "29";
            string Data = @"%windir%\System32\shell32.dll,51";

            using (RegistryKey Key = Registry.LocalMachine.CreateSubKey(Path))
            Key.SetValue(Name, Data, RegistryValueKind.String);

            foreach (var process in Process.GetProcessesByName("explorer")) { process.Kill(); }
            Process.Start("explorer.exe");
        }
    }
}
