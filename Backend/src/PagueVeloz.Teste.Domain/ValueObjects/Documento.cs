using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain
{
    public class Documento : ValueObject<Documento>
    {
        public readonly bool EhValido = false;
        public string Value { get; private set; }

        private Documento(string value)
        {
            Value = value;
            //validar
        }

        public static implicit operator Documento(string cnpj) => new Documento(cnpj);
        protected override bool EqualsCore(Documento other) => Value.Equals(other.Value);

        protected override int GetHashCodeCore()
        {
            return 0;
        }
    }
}