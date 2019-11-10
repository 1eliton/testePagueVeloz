using PagueVeloz.Teste.Application.DTOs;

namespace PagueVeloz.Teste.Application
{
    public interface IEmpresaAppService
    {
        void Cadastrar(CadastrarEmpresaDto cadastrarEmpresa);
        void VincularFornecedor(CadastrarFornecedorDto cadastrarFornecedorDto);
    }
}