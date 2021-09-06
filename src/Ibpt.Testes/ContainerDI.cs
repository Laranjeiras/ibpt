using Ibpt.Core.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Linq;

namespace Ibpt.Testes
{
    public abstract class ContainerDI
    {
        protected ServiceProvider ServiceProvider { get; private set; }

        public ContainerDI()
        {
            var services = new ServiceCollection();

            var diretorio = Directory.GetFiles(@"E:\Downloads\tabela-ibpt-21_2_A").ToList();
            services.AddSingleton<IIbptRepositorio>(x => new IbptCsvRepositorio(@"E:\Downloads\tabela-ibpt-21_2_A", "21.2"));

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}