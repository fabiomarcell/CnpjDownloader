using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CPFDownloader.Reader.Interfaces
{
    public class CnpjReader : ICnpjReader
    {
        private string BaseDir { get; set; } = $@"C:\temp\cpfs\unzip\";
        private string BaseDirProcessed { get; set; } = $@"C:\temp\cpfs\processed\";

        private LayoutVersions Layout { get; set; }
        public IEmpresaRepository<Empresa> EmpresaRepository { get; }

        public CnpjReader(IEmpresaRepository<Empresa> repo, string version = "")
        {
            Directory.CreateDirectory(BaseDir);
            Directory.CreateDirectory(BaseDirProcessed);
            EmpresaRepository = repo;
            this.CreateLayout(version);
        }

        private void CreateLayout(string version)
        {
            switch (version)
            {
                case "":
                    this.Layout = new LayoutDefaultVersion();
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void Execute()
        {
            //read
            ReadAll();

        }

        private void ReadAll()
        {
            foreach (var item in Directory.GetFiles(BaseDir))
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(item);
                var empresas = new List<Empresa>();

                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("0"))
                    {
                        continue;
                    }
                    
                    var identificador = line.Substring(Layout.IdentificadorIndex[0], Layout.IdentificadorIndex[1]);

                    if (identificador == "1")
                    {
                        //cnpj
                        var empresa = new Empresa()
                        {
                            CEP = line.Substring(Layout.CEPIndex[0], Layout.CEPIndex[1]),
                            Cnpj = line.Substring(Layout.CnpjIndex[0], Layout.CnpjIndex[1]),
                            DataSituacao = line.Substring(Layout.DataSituacaoIndex[0], Layout.DataSituacaoIndex[1]),
                            IsMatriz = line.Substring(Layout.IsMatrizIndex[0], Layout.IsMatrizIndex[1]) == "1",
                            NomeFantasia = line.Substring(Layout.NomeFantasiaIndex[0], Layout.NomeFantasiaIndex[1]),
                            RazaoSocial = line.Substring(Layout.RazaoSocialIndex[0], Layout.RazaoSocialIndex[1]),
                            SituacaoCadastral = line.Substring(Layout.SituacaoCadastralIndex[0], Layout.SituacaoCadastralIndex[1]),
                        };

                        empresas.Add(empresa);

                        EmpresaRepository.Save(empresa);
                    }

                    System.Console.WriteLine(line);
                }
            }
        }
    }
}
