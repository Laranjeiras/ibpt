using System;

namespace Ibtp.Core.Modelos
{
    public class Item
    {
        protected Item() { }

        public Item(string ncm, string descricao, Imposto imposto, Vigencia vigencia)
        {
            Ncm = ncm;
            Descricao = descricao;
            Imposto = imposto;
            Vigencia = vigencia;
        }

        public string Ncm { get; protected set; }
        public string Descricao { get; protected set; }
        public string DescricaoNormalizada => Descricao?.ToUpper();
        public Imposto Imposto { get; protected set; }
        public Vigencia Vigencia { get; protected set; }
    }
}
