using Ibtp.Core.Servicos;
using System;
using System.Diagnostics;

namespace Ibtp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var csv = @"E:\Downloads\11367874000106\TabelaIBPTaxRJ21.2.C.csv";

            var before0 = GC.CollectionCount(0);
            var before1 = GC.CollectionCount(1);
            var before2 = GC.CollectionCount(2);

            Stopwatch sw = new();
            sw.Start();

            var servico = new TabelaServico(csv, "21.2", Core.Tipos.eUF.RJ);

            var lista = servico.TabelaIbpt;

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
