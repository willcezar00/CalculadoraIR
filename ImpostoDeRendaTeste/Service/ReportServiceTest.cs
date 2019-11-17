using ImpostoDeRenda.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoDeRendaTeste.Service
{
    [TestClass]
    public class ReportServiceTest
    {
        private static readonly string filePath = "..\\..\\..\\Resources\\input.txt";

        [TestMethod]
        public void GerarReportSize5Test()
        {
            var pessoaService = PessoaService.GetInstance();
            var pessoas = pessoaService.ReadPessoas(filePath);

            var reportService = ReportService.GetInstance();
            var reports = reportService.GerarReport(pessoas);

            Assert.AreEqual(5, reports.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadPessoasFromFileFailTest()
        {
            var reportService = ReportService.GetInstance();
            var reports = reportService.GerarReport(null);
        }
    }
}
