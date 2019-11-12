using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain
{
    public class Documento : ValueObject<Documento>
    {
        public string Value { get; private set; }
        public TipoPessoa TipoPessoa { get; private set; }
        public readonly bool EhValido;

        private Documento(string value)
        {
            Value = value;
            if (Value.Length == 14)
            {
                CpfStruct cpf = value;
                TipoPessoa = TipoPessoa.Fisica;
                if (cpf.EhValido)
                {
                    Value = cpf.ToString();
                    EhValido = true;
                }
            }
            else
            {
                CnpjStruct cnpj = value;
                TipoPessoa = TipoPessoa.Juridica;
                if (cnpj.EhValido)
                {
                    Value = cnpj.ToString();
                    EhValido = true;
                }
            }
        }

        public static implicit operator Documento(string value)
            => new Documento(value);

        protected Documento() { }

        protected override bool EqualsCore(Documento other)
        {
            throw new System.NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new System.NotImplementedException();
        }
    }
}