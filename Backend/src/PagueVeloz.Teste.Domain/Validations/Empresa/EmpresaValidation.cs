using FluentValidation;
using PagueVeloz.Teste.Domain.Commands.Empresa;

namespace PagueVeloz.Teste.Domain
{
    public class EmpresaValidation<T> : AbstractValidator<T> where T : EmpresaCommand
    {
        protected void ValidateNomeFantasia()
        {
            RuleFor(e => e.NomeFantasia)
                .NotEmpty()
                .WithMessage("O nome da empresa não pode ser vazio.");

            RuleFor(e => e.NomeFantasia)
                .MaximumLength(150)
                .WithMessage("O nome da empresa não pode ter mais que 150 caractéres.");
        }

        protected void ValidateCnpj()
        {
            RuleFor(e => e.Cnpj)
                .Must(m => m.EhValido)
                .WithMessage("Cnpj da empresa precisa ser válido");
        }

        protected void ValidateUf()
        {
            RuleFor(e => e.Uf)
                .NotEmpty()
                .WithMessage("É necessário uma unidade federativa.");

            RuleFor(e => e.Uf)
                .Must(uf => uf.Length == 2)
                .WithMessage("A unidade federativa deve ter 2 caractéres.");

        }
    }
}