namespace PagueVeloz.Teste.Domain.Commands.Empresa
{
    public class CadastrarEmpresaCommand : EmpresaCommand
    {
        public CadastrarEmpresaCommand(string nomeFantasia, Cnpj cnpj, string uf)
        {
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Uf = uf;
        }
        public override bool IsValid()
        {
            ValidationResult = new CadastrarEmpresaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}