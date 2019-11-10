using System.ComponentModel;

namespace PagueVeloz.Teste.Domain
{
    public enum TipoPessoa : short
    {
        [Description("Pessoa física")]
        Fisica = 1,
        [Description("Pessoa Jurídica")]
        Juridica = 2
    }
}