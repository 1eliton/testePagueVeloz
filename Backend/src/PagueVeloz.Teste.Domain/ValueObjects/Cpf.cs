using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain
{
    public class Cpf : ValueObject<Cpf>
    {
        public readonly bool EhValido = false;
        private readonly string Value;


        private Cpf(string value)
        {
            Value = value;
            //validar
        }

        public static implicit operator Cpf(string cpf) => new Cpf(cpf);
        protected override bool EqualsCore(Cpf other) => Value.Equals(other.Value);
        protected override int GetHashCodeCore() => 0;
    }
}