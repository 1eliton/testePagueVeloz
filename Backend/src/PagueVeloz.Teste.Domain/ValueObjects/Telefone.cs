using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain
{
    public class Telefone : ValueObject<Telefone>
    {

        public readonly bool EhValido = false;
        public readonly string Value;

        private Telefone(string value)
        {
            Value = value;
            //validar
        }

        public static implicit operator Telefone(string cnpj) => new Telefone(cnpj);
        protected override bool EqualsCore(Telefone other) => Value.Equals(other.Value);

        protected override int GetHashCodeCore()
        {
            return 0;
        }
    }
}