using Ibpt.Core.Modelos;
using Ibpt.Core.Repositorios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Ibpt.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var before0 = GC.CollectionCount(0);
            var before1 = GC.CollectionCount(1);
            var before2 = GC.CollectionCount(2);

            Stopwatch sw = new();
            sw.Start();

            IIbptRepositorio servico = new IbptCsvRepositorio(@"E:\Downloads\tabela-ibpt-21_2_A", "21.2");

            var lista = servico.ObterTabelaPorUF(Core.Tipos.eUF.RJ);

            sw.Stop();
            var tempo = sw.Elapsed;

            Console.WriteLine($"REGISTROS: { lista.Count }");
            Console.WriteLine($"PROCESSADO EM {tempo.TotalSeconds} SEGUNDOS");
            Console.WriteLine($"# GEN0: {GC.CollectionCount(0) - before0}");
            Console.WriteLine($"# GEN1: {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"# GEN2: {GC.CollectionCount(2) - before2}");
            Console.WriteLine($"#MEMORY: {Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024} mb");
        }
    }
}
