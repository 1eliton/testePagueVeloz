using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain
{
    public class DataNascimento : ValueObject<DataNascimento>
    {
        public readonly bool EhValido = false;
        public readonly string Value;

        private DataNascimento(string value)
        {
            Value = value;
            //validar
        }

        public static implicit operator DataNascimento(string cnpj) => new DataNascimento(cnpj);
        protected override bool EqualsCore(DataNascimento other) => Value.Equals(other.Value);

        protected override int GetHashCodeCore()
        {
            return 0;
        }
    }
}