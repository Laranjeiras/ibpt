﻿using Ibtp.Core.Servicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ibtp.Testes
{
    [TestClass]
    public class TabelaBuilder_Teste : ContainerDI
    {
        [TestMethod]
        public void Importar_Teste()
        {
            var servico = (TabelaServico)ServiceProvider.GetService(typeof(TabelaServico));

            var lista = servico.TabelaIbpt;
            Assert.IsTrue(lista.Count > 0);

            var aliquota = servico.BuscarAliquota("27101932");
            Assert.IsNotNull(aliquota);
            Assert.IsNotNull(aliquota.Vigencia);
            Assert.IsNotNull(aliquota.Descricao);
            Assert.AreEqual(aliquota.Imposto.Federal, 13.45m);
            Assert.AreEqual(aliquota.Imposto.Importado, 17.39m);
            Assert.AreEqual(aliquota.Imposto.Estadual, 20m);
            Assert.AreEqual(aliquota.Imposto.Municipal, 0m);

            System.Console.WriteLine($"Total de registros importados: { lista.Count }");
        }
    }
}
