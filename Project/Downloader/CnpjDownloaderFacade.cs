using CPFDownloader.Downloader.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CPFDownloader.Downloader
{
    //efetivamente faz o download, com uso de lib externa
    public class CnpjDownloaderFacade: ICnpjDownloaderFacade
    {

        public string[] Hosts { get; set; } = new string[] {
            @"http://200.152.38.155/CNPJ/DADOS_ABERTOS_CNPJ_01.zip",
            @"http://200.152.38.155/CNPJ/DADOS_ABERTOS_CNPJ_02.zip"
        };
        private string BaseDir { get; set; } = $@"c:\temp\cpfs\";

        public CnpjDownloaderFacade()
        {
            Directory.CreateDirectory(BaseDir);
        }

        public void Execute()
        {
            foreach (var host in Hosts)
            {
                var wc = new System.Net.WebClient();
                //melhorar
                var filename = host.Split(@"/").Last();
                wc.DownloadFile(new Uri(host), $@"{BaseDir}{filename}");
            }
        }
    }
}
