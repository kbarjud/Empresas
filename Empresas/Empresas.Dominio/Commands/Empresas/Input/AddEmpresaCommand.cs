using System;

namespace Empresas.Dominio.Commands.Empresas.Input
{
    public class AddEmpresaCommand
    {
        public string CNPJ { get; set; }
        public string Inscricao_Estadual { get; set; }
        public string Nome_Empresarial { get; set; }
        public string Nome_Fantasia { get; set; }
        public string Atividade_Economica { get; set; }
        public string Telefone_Fixo { get; set; }
        public string? Whatsapp { get; set; }
        public string Logradouro { get; set; }
        public int Num_Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string Status { get; set; }
        public DateTime Data_Abertura { get; set; }
        public DateTime? Data_Modificacao { get; set; }
        public DateTime? Data_Encerramento { get; set; }

    }
}
