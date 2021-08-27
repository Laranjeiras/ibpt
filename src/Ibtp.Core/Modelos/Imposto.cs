namespace Ibtp.Core.Modelos
{
    public class Imposto
    {
        protected Imposto() { }

        public Imposto(decimal federal, decimal estadual, decimal importado)
        {
            Federal = federal;
            Estadual = estadual;
            Importado = importado;
        }

        public decimal Federal { get; protected set; }
        public decimal Estadual { get; protected set; }
        public decimal Importado { get; protected set; }
    }

}
