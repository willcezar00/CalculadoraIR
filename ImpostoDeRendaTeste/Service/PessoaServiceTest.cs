using ImpostoDeRenda.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoDeRendaTeste.Service
{
    [TestClass]
    public class PessoaServiceTest
    {
        private static readonly string filePath = "..\\..\\..\\Resources\\input.txt";

        [TestMethod]
        public void ReadPessoasFromFileSize5Test()
        {
            var pessoaService = PessoaService.GetInstance();
            var pessoas = pessoaService.ReadPessoas(filePath);
            Assert.AreEqual(5, pessoas.Count);
        }

    }
}
