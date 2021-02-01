
using CPFDownloader.Downloader;
using CPFDownloader.Downloader.Interfaces;
using CPFDownloader.Reader;
using CPFDownloader.Reader.Interfaces;
using Domain.Entities;
using Domain.Repository;
using Infra.MongoDb;
using Infra.MongoDb.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CPFDownloader
{
    class Startup
    {
        public IServiceProvider Provider;
        public Startup()
        {
            var services = new ServiceCollection();
            services.AddScoped<ICnpjDownloader, CnpjDownloader>();
            services.AddScoped<ICnpjDownloaderFacade, CnpjDownloaderFacade>();
            services.AddScoped<IZipManager, ZipManager>();
            services.AddScoped<ICnpjReader, CnpjReader>();
            services.AddScoped<IEmpresaRepository<Empresa>, EmpresaRepository>();
            services.AddSingleton<IMongoDb>(s => {
                return new MongoDb();
            });
            //services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            Provider = services.BuildServiceProvider();
        }

    }
}
