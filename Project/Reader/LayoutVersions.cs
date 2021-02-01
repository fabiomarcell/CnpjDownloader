using CPFDownloader.Reader.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPFDownloader.Reader
{
    public abstract class LayoutVersions 
    {
        public int[] TipoDeRegistro { get; set; } = new int[] { 0, 0 };

        public int[] CnpjIndex { get; set; } = new int[] { 0, 0 };
        public int[] IsMatrizIndex { get; set; } = new int[] { 0, 0 };
        public int[] RazaoSocialIndex { get; set; } = new int[] { 0, 0 };
        public int[] NomeFantasiaIndex { get; set; } = new int[] { 0, 0 };
        public int[] CapitalSocialIndex { get; set; } = new int[] { 0, 0 };
        public int[] SituacaoCadastralIndex { get; set; } = new int[] { 0, 0 };
        public int[] DataSituacaoIndex { get; set; } = new int[] { 0, 0 };
        public int[] CEPIndex { get; set; } = new int[] { 0, 0 };


        public int[] IdentificadorIndex { get; set; } = new int[] { 0, 0 };
        public int[] NomeIndex { get; set; } = new int[] { 0, 0 };
        public int[] Cpf_CnpjIndex { get; set; } = new int[] { 0, 0 };

    }
}
