using Ibtp.Core.Modelos;
using Ibtp.Core.Tipos;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ibtp.Core.Servicos
{
    public class TabelaServico
    {
        private readonly string versao;
        private readonly eUF uf;
        public readonly IList<Item> TabelaIbpt = new List<Item>();

        public TabelaServico(string localCsv, string versao, eUF uf)
        {
            this.versao = versao;
            this.uf = uf;

            TabelaIbpt = Mapear(localCsv);
        }

        public Item BuscarAliquota(string ncm)
        {
            return TabelaIbpt.FirstOrDefault(x => x.Ncm == ncm);
        }

        private IList<Item> Mapear(string localCsv)
        {
            string linha;
            int count = 0;
            var lista = new List<Item>();

            using (var fs = File.OpenRead(localCsv))
            using (var stream = new StreamReader(fs))
                while ((linha = stream.ReadLine()) != null)
                {
                    var item = Item.Mapear.MapearDaStringCsv(linha);
                    if (item != null)
                        lista.Add(item);
                    count++;
                }

            return lista;
        }
    }
}
