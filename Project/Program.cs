using CPFDownloader.Downloader;
using CPFDownloader.Downloader.Interfaces;
using CPFDownloader.Reader;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CPFDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();

            var servicedownloader = startup.Provider.GetRequiredService<ICnpjDownloader>();

            //servicedownloader.Execute();

            var serviceReader = startup.Provider.GetRequiredService<ICnpjReader>();

            serviceReader.Execute();

        }
    }
}
