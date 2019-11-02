using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain
{
    public class Rg : ValueObject<Rg>
    {
        public readonly bool EhValido = false;
        public string Value { get; private set; }

        private Rg(string value)
        {
            Value = value;
            //validar
        }

        public static implicit operator Rg(string cnpj) => new Rg(cnpj);
        protected override bool EqualsCore(Rg other) => Value.Equals(other.Value);

        protected override int GetHashCodeCore()
        {
            return 0;
        }
    }
}