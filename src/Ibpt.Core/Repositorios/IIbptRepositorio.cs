using Ibpt.Core.Modelos;
using Ibpt.Core.Tipos;
using System.Collections.Generic;

namespace Ibpt.Core.Repositorios
{
    public interface IIbptRepositorio
    {
        public IList<Item> TabelaIbpt { get; set; }
        public IList<Item> ObterTabelaPorUF(eUF uf);
        public Item ObterPorNcm(string ncm, eUF uf);
    }
}
