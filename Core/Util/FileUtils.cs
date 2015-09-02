using System;
using System.IO;

namespace PraiseBase.Presenter.Util
{
    public static class FileUtils
    {
        /// <summary>
        ///     Tests if two files are equal
        /// </summary>
        /// <param name="path1">First file path</param>
        /// <param name="path2">Second file path</param>
        /// <param name="throwException">If set to true, throw an exception instead of returning false</param>
        /// <returns>Returns true if the files are equal, else false</returns>
        public static bool FileEquals(string path1, string path2, bool throwException = false)
        {
            var file1 = File.ReadAllBytes(path1);
            var file2 = File.ReadAllBytes(path2);
            if (file1.Length == file2.Length)
            {
                for (var i = 0; i < file1.Length; i++)
                {
                    if (file1[i] != file2[i])
                    {
                        if (throwException)
                        {
                            throw new Exception("Difference at position " + i + "! " + FindDifference(path1, path2));
                        }
                        return false;
                    }
                }
                return true;
            }
            if (throwException)
            {
                throw new Exception("File lenght not equal! " + FindDifference(path1, path2));
            }
            return false;
        }

        public static string FindDifference(string path1, string path2)
        {
            var lines1 = File.ReadAllLines(path1);
            var lines2 = File.ReadAllLines(path2);
            for (var j = 0; j < Math.Max(lines1.Length, lines2.Length); j++)
            {
                if (lines1.Length <= j || lines2.Length <= j)
                {
                    return string.Empty;
                }
                if (!lines1[j].Equals(lines2[j]))
                {
                    return "Difference at line " + j + ": < " + lines1[j] + " > " + lines2[j];
                }
            }
            return string.Empty;
        }

        /// <summary>
        ///     Removes all empty subdirectories
        /// </summary>
        /// <param name="startLocation"></param>
        public static void RemoveEmptySubdirectories(string startLocation)
        {
            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                RemoveEmptySubdirectories(directory);
                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }
    }
}