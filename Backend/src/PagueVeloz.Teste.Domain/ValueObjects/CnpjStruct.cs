using System;

namespace PagueVeloz.Teste.Domain
{
    public struct CnpjStruct
    {
        private readonly string _value;
        public readonly bool EhValido;

        private CnpjStruct(string value)
        {
            var cnpj = value;
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;

            int resto;

            string digito;

            string tempCnpj;

            cnpj = cnpj.Trim();

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
            {
                EhValido = false;
            }

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;

            for (int i = 0; i < 12; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            EhValido = cnpj.EndsWith(digito);
            _value = cnpj;
            _value = long.Parse(_value).ToString(@"00\.000\.000\/0000\-00");
        }

        public static implicit operator CnpjStruct(string value)
            => new CnpjStruct(value);

        public override string ToString() => _value;
    }
}