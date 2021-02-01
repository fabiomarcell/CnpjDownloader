using CPFDownloader.Downloader.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace CPFDownloader.Downloader
{
    public class ZipManager : IZipManager
    {

        public void UnzipDir(string dir)
        {
            throw new NotImplementedException();
        }

        public void UnzipDirAndMove(string dir, string destination)
        {

            foreach (var item in Directory.GetFiles(dir))
            {
                using (StreamReader st = new StreamReader(item))
                {

                    using (ZipArchive archive = new ZipArchive(st.BaseStream, ZipArchiveMode.Read))
                    {
                        foreach (var itemunziped in archive.Entries)
                        {
                            itemunziped.ExtractToFile($"{destination}{itemunziped.FullName}", true);
                        }
                    }
                }
            }
        }
    }
}
