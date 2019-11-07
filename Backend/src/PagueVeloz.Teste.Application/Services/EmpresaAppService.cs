using PagueVeloz.Teste.Application.DTOs;
using PagueVeloz.Teste.Domain.Commands.Empresa;
using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Application
{
    public class EmpresaAppService : IEmpresaAppService
    {
        private readonly IMediatorHandler _mediator;

        public EmpresaAppService(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public void Cadastar(CadastrarEmpresaDto cadastrarEmpresa)
        {
            _mediator.SendCommand(new CadastrarEmpresaCommand(cadastrarEmpresa.NomeFantasia, cadastrarEmpresa.Cnpj, cadastrarEmpresa.Uf));
        }
    }
}