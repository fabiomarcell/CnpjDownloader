using System;
using System.Collections.Generic;
using System.Text;

namespace CPFDownloader.Reader
{
    public class LayoutDefaultVersion : LayoutVersions
    {
        public LayoutDefaultVersion()
        {
            TipoDeRegistro = new int[] { 0, 1 };

            /****tipo registro 1****/
            CnpjIndex = new int[] { 3, 14 };
            IsMatrizIndex = new int[] { 17, 1 };
            RazaoSocialIndex = new int[] { 18, 150 };
            NomeFantasiaIndex = new int[] { 168, 55 };
            SituacaoCadastralIndex = new int[] { 223, 2 };
            DataSituacaoIndex = new int[] { 225, 8 };
            CEPIndex = new int[] { 674, 8 };


            /****tipo registro 2****/
            IdentificadorIndex = new int[] { 17, 1 };
            NomeIndex = new int[] { 18, 150 };
            Cpf_CnpjIndex = new int[] { 168, 14 };
        }
    }
}
