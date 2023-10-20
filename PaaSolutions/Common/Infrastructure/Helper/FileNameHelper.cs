using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.Helper
{
    public class FileNameHelper
    {
        private static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }

        public static string GetWriteableFilePath(string path, string filename, string extension)
        {
            string tempFileNameWithoutExtension = MakeValidFileName(filename);
            string tempFilePath = string.Format("{0}.{1}", path + tempFileNameWithoutExtension, extension);
            int i = 0;
            while (true)
            {
                try
                {
                    File.Delete(tempFilePath);
                }
                catch (Exception e)
                {
                    tempFilePath = string.Format("{0} - {1}.{2}", path + tempFileNameWithoutExtension, i.ToString("D6"), extension);
                    i += 1;
                    continue;
                }
                break;
            }
            return tempFilePath;
        }
    }
}
