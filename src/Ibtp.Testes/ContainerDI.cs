using Ibtp.Core.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Ibtp.Testes
{
    public abstract class ContainerDI
    {
        protected ServiceProvider ServiceProvider { get; private set; }

        public ContainerDI()
        {
            var services = new ServiceCollection();
            var csv = @"E:\Downloads\11367874000106\TabelaIBPTaxRJ21.2.C.csv";
            services.AddSingleton<TabelaServico>(x => new TabelaServico(csv, "21.2", Core.Tipos.eUF.RJ));
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}