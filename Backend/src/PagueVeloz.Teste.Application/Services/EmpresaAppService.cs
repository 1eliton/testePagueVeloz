using PagueVeloz.Teste.Application.DTOs;
using PagueVeloz.Teste.Domain.Commands;
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

        public void Cadastrar(CadastrarEmpresaDto cadastrarEmpresa)
        {
            _mediator.SendCommand(
                new CadastrarEmpresaCommand(cadastrarEmpresa.NomeFantasia, cadastrarEmpresa.Cnpj, cadastrarEmpresa.Uf));
        }

        public void VincularFornecedor(CadastrarFornecedorDto cadastrarFornecedorDto)
        {
            _mediator.SendCommand(
                new VincularFornecedorEmpresaCommand(cadastrarFornecedorDto.IdEmpresa,
                cadastrarFornecedorDto.Nome,
                cadastrarFornecedorDto.Rg, cadastrarFornecedorDto.DataNascimento, cadastrarFornecedorDto.Documento,
                cadastrarFornecedorDto.Telefone));
        }
    }
}