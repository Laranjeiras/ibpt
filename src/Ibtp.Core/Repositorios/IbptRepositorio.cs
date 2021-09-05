using Ibtp.Core.Modelos;
using Ibtp.Core.Tipos;
using System.Collections.Generic;
using System.Linq;

namespace Ibtp.Core.Repositorios
{
    public abstract class IbptRepositorio: IIbptRepositorio
    {
        protected readonly string versao;
        public IList<Item> TabelaIbpt { get; set; }

        public IbptRepositorio(string versao)
        {
            this.versao = versao;
            TabelaIbpt = new List<Item>();
        }

        public Item ObterPorNcm(string ncm, eUF uf)
        {
            return TabelaIbpt.FirstOrDefault(x => x.Ncm == ncm && x.Imposto.UF == uf);
        }

        public IList<Item> ObterTabelaPorUF(eUF uf)
        {
            return TabelaIbpt.Where(x => x.Imposto.UF == uf).ToList();
        }
    }
}
