using System;
using System.Collections.Generic;
using System.Text;

namespace CPFDownloader.Downloader.Interfaces
{
    public interface IZipManager
    {
        void UnzipDir(string dir);

        void UnzipDirAndMove(string dir, string destination);
    }
}
