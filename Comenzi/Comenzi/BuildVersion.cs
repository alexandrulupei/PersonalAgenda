using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comenzi
{
  public  class BuildVersion
    {
        public static string GetVersion()
        {
            return GetVersion(1);
        }

        // 1 - Stream, 2 - Build, 3 - File
        public static string GetVersion(int mode)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            System.Version v = new Version(a.GetName().Version.ToString());
            string result = "Versiune " + v.Major.ToString() + "." + v.Minor.ToString() + "." + v.Build.ToString();

            System.DateTime d;

            switch (mode)
            {
                case 1: d = RetrieveLinkerTimestamp(a);
                    break;
                case 2: d = AssemblyBuildDate(a);
                    break;
                case 3: d = AssemblyLastWriteTime(a);
                    break;
                default: d = RetrieveLinkerTimestamp(a);
                    break;
            }
            if (d != System.DateTime.MaxValue)
            {
                result += " (" + d.ToString("yyyy-MM-dd") + ")";
            }
            return result;
        }

        // Stream Version
        private static System.DateTime RetrieveLinkerTimestamp(System.Reflection.Assembly a)
        {
            try
            {
                string filePath = a.Location;
                const int peHeaderOffset = 60;
                const int linkerTimestampOffset = 8;
                var b = new byte[2048];
                System.IO.FileStream s = null;
                try
                {
                    s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    s.Read(b, 0, 2048);
                }
                finally
                {
                    if (s != null)
                        s.Close();
                }
                var dt = new System.DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(System.BitConverter.ToInt32(b, System.BitConverter.ToInt32(b, peHeaderOffset) + linkerTimestampOffset));
                return dt.AddHours(System.TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            }
            catch
            {
                return DateTime.MaxValue;
            }
        }

        // Build Version
        private static System.DateTime AssemblyBuildDate(System.Reflection.Assembly a, bool forceFileDate)
        {
            System.DateTime dt;
            try
            {
                System.Version v = a.GetName().Version;
                if (forceFileDate)
                {
                    dt = AssemblyLastWriteTime(a);
                }
                else
                {
                    dt = new System.DateTime(2000, 1, 1, 0, 0, 0).AddDays(v.Build).AddSeconds(v.Revision * 2);
                    if (TimeZone.IsDaylightSavingTime(dt, TimeZone.CurrentTimeZone.GetDaylightChanges(dt.Year)))
                    {
                        dt = dt.AddHours(1);
                    }
                    if (dt > System.DateTime.Now || dt < new System.DateTime(2000, 1, 1, 0, 0, 0))
                    {
                        dt = AssemblyLastWriteTime(a);
                    }
                }
            }
            catch
            {
                dt = System.DateTime.MaxValue;
            }
            return dt;
        }

        private static System.DateTime AssemblyBuildDate(System.Reflection.Assembly a)
        {
            return AssemblyBuildDate(a, false);
        }

        // File Version
        private static System.DateTime AssemblyLastWriteTime(System.Reflection.Assembly a)
        {
            try
            {
                return System.IO.File.GetLastWriteTime(a.Location);
            }
            catch
            {
                return System.DateTime.MaxValue;
            }
        }
    }
}
