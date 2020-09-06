using APIMediatr.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace APIMediatr.Api.Repositories
{
    public class PessoaRepository : IRepository<Pessoa>
    {
        private List<Pessoa> _lista = new List<Pessoa>();

        public async Task Add(Pessoa item)
        {
            await Task.Run(() => _lista.Add(item));
        }

        public async Task Delete(string id)
        {
            await Task.Run(() => _lista.RemoveAll(x => x.Id.Equals(id)));
        }

        public async Task Edit(Pessoa item)
        {
            await Task.Run(() => 
            {
                _lista.RemoveAll(x => x.Id.Equals(item.Id));
                _lista.Add(item);
            });
        }

        public Task<Pessoa> Get(string id)
        {
            return Task.Run(() => _lista.FirstOrDefault(x => x.Id.Equals(id)));
        }

        public Task<IEnumerable<Pessoa>> GetAll()
        {
            IEnumerable<Pessoa> listaRetorno = _lista;
            return Task.Run(() => listaRetorno);
        }
    }
}
