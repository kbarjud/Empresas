using System;

namespace Empresas.Dominio.Entidades
{
    public class Empresa
    {
        public string CNPJ { get; private set; }
        public string Inscricao_Estadual { get; private set; }
        public string Nome_Empresarial { get; private set; }
        public string Nome_Fantasia { get; private set; }
        public string Atividade_Economica { get; private set; }
        public string Telefone_Fixo { get; private set; }
        public string? Whatsapp { get; private set; }
        public string Logradouro { get; private set; }
        public int Num_Logradouro { get; private set; }
        public string? Complemento { get; private set; }
        public string CEP { get; private set; }
        public string Bairro { get; private set; }
        public string Municipio { get; private set; }
        public string UF { get; private set; }
        public string Status { get; private set; }
        public DateTime Data_Abertura { get; private set; }
        public DateTime? Data_Modificacao { get; private set; }
        public DateTime? Data_Encerramento { get; private set; }

        public Empresa (string cnpj, string inscricao_estadual, string nome_empresarial, string nome_fantasia, string atividade_economida, 
            string telefone_fixo, string? whatsapp, string logradouro, int num_logradouro, string? complemento, string cep, string bairro,
            string municipio, string uf, string status, DateTime data_abertura, DateTime? data_modificacao, DateTime? data_encerramento)
        {
            CNPJ = cnpj;
            Inscricao_Estadual = inscricao_estadual;
            Nome_Empresarial = nome_empresarial;
            Nome_Fantasia = nome_fantasia;
            Atividade_Economica = atividade_economida;
            Telefone_Fixo = telefone_fixo;
            Whatsapp = whatsapp;
            Logradouro = logradouro;
            Num_Logradouro = num_logradouro;
            Complemento = complemento;
            CEP = cep;
            Bairro = bairro;
            Municipio = municipio;
            UF = uf;
            Status = status;
            Data_Abertura = data_abertura;
            Data_Modificacao = data_modificacao;
            Data_Encerramento = data_encerramento;
        }
    }
}
