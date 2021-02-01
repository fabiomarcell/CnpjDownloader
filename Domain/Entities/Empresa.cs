using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Empresa
	{
        public string Cnpj { get; set; }
		public bool IsMatriz { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CapitalSocial { get; set; }
        public string SituacaoCadastral{ get; set; }
        public string DataSituacao { get; set; }
        public string CEP { get; set; }
        public List<Socio> Socios{ get; set; }
	}
}
