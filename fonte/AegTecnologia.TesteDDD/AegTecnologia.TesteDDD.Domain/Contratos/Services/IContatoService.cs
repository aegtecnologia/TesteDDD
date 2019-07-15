using AegTecnologia.TesteDDD.Domain.Dominios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AegTecnologia.TesteDDD.Domain.Contratos.Services
{
    interface IContatoService
    {
        Task<List<Contato>> GetAll();
        Task<Contato> GetByName();
        Task<Contato> GetByEmail();
        Task Salvar(Contato contato);
        Task Excluir(Contato contato);
        Task Atualizar(Contato contato);
    }
}
