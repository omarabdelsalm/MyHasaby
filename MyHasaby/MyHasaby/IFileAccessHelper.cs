using System;
using System.Collections.Generic;
using System.Text;

namespace MyHasaby
{
  public  interface IFileAccessHelper
    {
        string GetLocalFilePath(string fileName);
        string GetDBPath(string dbpath);
        void CopyFile(string sourceFilename, string destinationFilename, bool overwrite);
        bool DoesFileExist(string fileName);
    }
}
