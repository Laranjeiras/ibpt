using Ibpt.Core.Tipos;
using System;

namespace Ibpt.Core.Modelos
{
    public class Item
    {
        protected Item() { }

        public Item(string ncm, string ex, string tipo, string descricao, Imposto imposto, Vigencia vigencia)
        {
            Ncm = ncm;
            Ex = ex;
            Tipo = tipo;
            Descricao = descricao;
            Imposto = imposto;
            Vigencia = vigencia;
        }

        public string Ncm { get; protected set; }
        public string Ex { get; protected set; }
        public string Tipo { get; protected set; }
        public string Descricao { get; protected set; }
        public string DescricaoNormalizada => Descricao?.ToUpper();
        public Imposto Imposto { get; protected set; }
        public Vigencia Vigencia { get; protected set; }

        public static class Mapear
        {

        }
    }
}
