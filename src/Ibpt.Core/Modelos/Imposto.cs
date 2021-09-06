using Ibpt.Core.Tipos;

namespace Ibpt.Core.Modelos
{
    public class Imposto
    {
        protected Imposto() { }

        public Imposto(eUF uf, decimal federal, decimal estadual, decimal municipal, decimal importado)
        {
            UF = uf;
            Federal = federal;
            Estadual = estadual;
            Importado = importado;
            Municipal = municipal;
        }

        public eUF UF { get; protected set; }

        /// <summary>
        /// Tributação Federal para Produtos Nacionais
        /// </summary>
        public decimal Federal { get; protected set; }

        /// <summary>
        /// Tributação Estadual
        /// </summary>
        public decimal Estadual { get; protected set; }

        /// <summary>
        /// Tributação Federal para Produtos Importados
        /// </summary>
        public decimal Importado { get; protected set; }


        /// <summary>
        /// Tributação Municipal
        /// </summary>
        public decimal Municipal { get; protected set; }
    }

}
