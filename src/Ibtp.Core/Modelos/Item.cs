using System;

namespace Ibtp.Core.Modelos
{
    public class Item
    {
        protected Item() { }

        public string Ncm { get; protected set; }
        public string Ex { get; protected set; }
        public string Descricao { get; protected set; }
        public string DescricaoNormalizada => Descricao?.ToUpper();
        public Imposto Imposto { get; protected set; }
        public Vigencia Vigencia { get; protected set; }

        public static class Mapear
        {
            public static Item MapearDaStringCsv(string linha)
            {
                try
                {
                    var colunas = linha.Split(";");
                    var impFederal = decimal.Parse(colunas[4].Replace(".",","));
                    var impImportado = decimal.Parse(colunas[5].Replace(".", ","));
                    var impEstadual = decimal.Parse(colunas[6].Replace(".", ","));
                    var impMunicipal = decimal.Parse(colunas[7].Replace(".", ","));

                    DateTime.TryParse(colunas[8], out DateTime vigInicio);
                    DateTime.TryParse(colunas[9], out DateTime vigFim);

                    var imposto = new Imposto(impFederal, impEstadual, impMunicipal, impImportado);
                    var vigencia = new Vigencia(vigInicio, vigFim);

                    var item = new Item();
                    item.Ncm = colunas[0];
                    item.Descricao = colunas[3];
                    item.Imposto = imposto;
                    item.Vigencia = vigencia;
                    return item;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao mapear essa linha");
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
    }
}
