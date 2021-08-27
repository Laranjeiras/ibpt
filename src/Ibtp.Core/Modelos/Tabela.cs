using Ibtp.Core.Tipos;
using System.Collections.Generic;

namespace Ibtp.Core.Modelos
{
    public class Tabela
    {
        protected Tabela() { }

        public Tabela(eUF uF, string versao)
        {
            UF = uF;
            Versao = versao;
        }

        public eUF UF { get; protected set; }
        public string Versao { get; protected set; }
        public IList<Item> Itens { get; protected set; }
    }
}
