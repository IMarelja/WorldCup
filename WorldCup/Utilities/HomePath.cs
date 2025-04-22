using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Utilities
{
    public class HomePath
    {
        public static string Value()
        {

            if (!DebugDirectoryChecker())
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
            return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName; //Issue
        }

        private static bool DebugDirectoryChecker()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            var normalizedPath = Path.GetFullPath(baseDir)
                                     .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                                     .ToLowerInvariant();

            return normalizedPath.Contains(Path.Combine("bin", "debug").ToLowerInvariant()) ||
                   normalizedPath.Contains(Path.Combine("bin", "release").ToLowerInvariant());
        }
    }
}
