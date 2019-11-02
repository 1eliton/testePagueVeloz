using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain
{
    public class Cnpj : ValueObject<Cnpj>
    {
        public readonly bool EhValido = false;
        public string Value { get; private set; }

        private Cnpj(string value)
        {
            Value = value;
            //validar
        }

        public static implicit operator Cnpj(string cnpj) => new Cnpj(cnpj);
        protected override bool EqualsCore(Cnpj other) => Value.Equals(other.Value);

        protected override int GetHashCodeCore()
        {
            return 0;
        }
    }
}