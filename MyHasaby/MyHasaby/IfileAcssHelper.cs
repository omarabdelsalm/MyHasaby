using System;
using System.Collections.Generic;
using System.Text;

namespace MyHasaby
{
   public interface IfileAcssHelper
    {
        string GetLocationFilePath(string fileName);
        void CobyFile(string sourceFilename, string destinationFilename, bool overwrite);
        bool DoesFileExist(string fileName);
    }
}
