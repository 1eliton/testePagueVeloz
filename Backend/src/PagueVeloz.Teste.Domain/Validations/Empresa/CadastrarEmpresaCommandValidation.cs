using FluentValidation;
using PagueVeloz.Teste.Domain.Commands.Empresa;

namespace PagueVeloz.Teste.Domain
{
    public class CadastrarEmpresaCommandValidation : EmpresaValidation<CadastrarEmpresaCommand>
    {
        public CadastrarEmpresaCommandValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            ValidateCnpj();
            ValidateNomeFantasia();
            ValidateUf();
        }
    }
}