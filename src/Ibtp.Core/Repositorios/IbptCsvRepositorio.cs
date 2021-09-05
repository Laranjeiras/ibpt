using Ibtp.Core.Modelos;
using Ibtp.Core.Tipos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ibtp.Core.Repositorios
{
    public sealed class IbptCsvRepositorio : IbptRepositorio
    {
        public IbptCsvRepositorio(string diretorio, string versao) : base(versao)
        {
            var arquivos = Directory.GetFiles(diretorio).ToList();

            foreach (var arquivo in arquivos)
            {
                try
                {
                    if (!ArquivoValido(arquivo))
                        continue;

                    var uf = ExtrairUF(arquivo);

                    var itens = Mapear(arquivo, uf);

                    foreach (var item in itens)
                        TabelaIbpt.Add(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }
            }
        }

        private bool ArquivoValido(string arquivo)
        {
            var filename = Path.GetFileName(arquivo);

            var startsWith = filename.StartsWith("TabelaIBPTax");
            var ext = Path.GetExtension(filename);

            return (startsWith && ext == ".csv");
        }

        private eUF ExtrairUF(string arquivo)
        {
            var filename = Path.GetFileName(arquivo);

            var uf = filename.Substring(12, 2);
            var eUF = (eUF)Enum.Parse(typeof(eUF), uf, true);
            return eUF;
        }

        private IList<Item> Mapear(string localCsv, eUF uf)
        {
            string linha;
            int count = 0;
            var lista = new List<Item>();

            using (var fs = File.OpenRead(localCsv))
            using (var stream = new StreamReader(fs))
                while ((linha = stream.ReadLine()) != null)
                {
                    var item = MapearDaStringCsv(linha, uf);
                    if (item != null)
                        lista.Add(item);
                    count++;
                }

            return lista;
        }

        private Item MapearDaStringCsv(string linha, eUF uf)
        {
            try
            {
                var colunas = linha.Split(";");
                var impFederal = decimal.Parse(colunas[4].Replace(".", ","));
                var impImportado = decimal.Parse(colunas[5].Replace(".", ","));
                var impEstadual = decimal.Parse(colunas[6].Replace(".", ","));
                var impMunicipal = decimal.Parse(colunas[7].Replace(".", ","));

                DateTime.TryParse(colunas[8], out DateTime vigInicio);
                DateTime.TryParse(colunas[9], out DateTime vigFim);

                var imposto = new Imposto(uf, impFederal, impEstadual, impMunicipal, impImportado);
                var vigencia = new Vigencia(vigInicio, vigFim);

                var ncm = colunas[0];
                var ex = colunas[1];
                var tipo = colunas[2];
                var descricao = colunas[3];

                var item = new Item(ncm, ex, tipo, descricao, imposto, vigencia);
                return item;
            }
            catch (Exception ex)
            {
                if (linha.StartsWith("codigo;ex;tipo;descricao;nacionalfederal;"))
                    return null;

                Console.WriteLine("Ocorreu um erro ao mapear essa linha");
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
