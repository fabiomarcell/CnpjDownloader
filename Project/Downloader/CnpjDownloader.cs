using CPFDownloader.Downloader.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CPFDownloader.Downloader
{
    //responsável por baixar e designar o dir de armazenamento 
    public class CnpjDownloader: ICnpjDownloader
    {
        private ICnpjDownloaderFacade CpfDownloaderFacade { get; set; }
        private IZipManager Zip { get; }

        private string BaseDir { get; set; } = $@"c:\temp\cpfs\";
        private string UnzipBaseDir { get; set; } = $@"c:\temp\cpfs\unzip\";


        public CnpjDownloader(ICnpjDownloaderFacade cpfdownload, IZipManager zip)
        {
            CpfDownloaderFacade = cpfdownload;
            Zip = zip;
            Directory.CreateDirectory(UnzipBaseDir);
        }

        public void Execute()
        {
            //essa etapa é bem lenta
            CpfDownloaderFacade.Execute();

            //unzip here, and store
            Zip.UnzipDirAndMove(BaseDir, UnzipBaseDir);
        }
    }
}
