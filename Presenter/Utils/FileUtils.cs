using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Pbp.Utils
{
    public static class FileUtils
    {
        /// <summary>
        /// Tests if two files are equal
        /// </summary>
        /// <param name="path1">First file path</param>
        /// <param name="path2">Second file path</param>
        /// <param name="throwException">If set to true, throw an exception instead of returning false</param>
        /// <returns>Returns true if the files are equal, else false</returns>
        public static bool FileEquals(string path1, string path2, bool throwException = false)
        {
            byte[] file1 = File.ReadAllBytes(path1);
            byte[] file2 = File.ReadAllBytes(path2);
            if (file1.Length == file2.Length)
            {
                for (int i = 0; i < file1.Length; i++)
                {
                    if (file1[i] != file2[i])
                    {
                        if (throwException)
                        {
                            throw new Exception("Difference at position " + i);
                        }
                        return false;
                    }
                }
                return true;
            }
            if (throwException)
            {
                throw new Exception("File lenght not equal");
            }
            return false;
        }
    }
}
