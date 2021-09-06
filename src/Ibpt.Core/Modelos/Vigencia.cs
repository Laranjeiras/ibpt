using System;

namespace Ibpt.Core.Modelos
{
    public class Vigencia
    {
        protected Vigencia() { }

        public Vigencia(DateTime inicio, DateTime fim)
        {
            Inicio = inicio;
            Fim = fim;
        }
                
        public DateTime Inicio { get; protected set; }
        public DateTime Fim { get; protected set; }
    }
}
