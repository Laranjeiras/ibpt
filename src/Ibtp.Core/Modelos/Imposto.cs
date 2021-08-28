namespace Ibtp.Core.Modelos
{
    public class Imposto
    {
        protected Imposto() { }

        public Imposto(decimal federal, decimal estadual, decimal municipal, decimal importado)
        {
            Federal = federal;
            Estadual = estadual;
            Importado = importado;
            Municipal = municipal;
        }

        public decimal Federal { get; protected set; }
        public decimal Estadual { get; protected set; }
        public decimal Importado { get; protected set; }
        public decimal Municipal { get; protected set; }
    }

}
