using ImpostoDeRenda.Domain;
using ImpostoDeRenda.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoDeRendaTeste.Repository
{
    [TestClass]
    public  class UtilsTest
    {
        [TestMethod]
        public void ConvertToTipoRendimentoSALARIOTest()
        {
            var tipoRendimento = Utils.ConvertToTipoRendimento("salário");
            Assert.AreEqual(TipoRendimento.SALARIO, tipoRendimento);
        }

        [TestMethod]
        public void ConvertToTipoRendimentoOUTROSTest()
        {
            var tipoRendimento = Utils.ConvertToTipoRendimento("outros");
            Assert.AreEqual(TipoRendimento.OUTROS, tipoRendimento);
        }

        [TestMethod]
        public void ConvertToTipoRendimentoREFORMATest()
        {
            var tipoRendimento = Utils.ConvertToTipoRendimento("reforma");
            Assert.AreEqual(TipoRendimento.REFORMA, tipoRendimento);
        }

        [TestMethod]
        public void ConvertToTipoRendimentoAPOSENTADORIATest()
        {
            var tipoRendimento = Utils.ConvertToTipoRendimento("aposentadoria");
            Assert.AreEqual(TipoRendimento.APOSENTADORIA, tipoRendimento);
        }

        [TestMethod]
        public void ConvertToTipoRendimentoPENSAOTest()
        {
            var tipoRendimento = Utils.ConvertToTipoRendimento("pensao");
            Assert.AreEqual(TipoRendimento.PENSAO, tipoRendimento);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ConvertToTipoRendimentoPENSAOFailTest()
        {
            var tipoRendimento = Utils.ConvertToTipoRendimento("persao");
            Assert.AreEqual(TipoRendimento.PENSAO, tipoRendimento);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ConvertToTipoRendimentoOUTROSFailTest()
        {
            var tipoRendimento = Utils.ConvertToTipoRendimento("outros21");
            Assert.AreEqual(TipoRendimento.PENSAO, tipoRendimento);
        }

        [TestMethod]
        public void ConvertToBoolSuccesFalseTest()
        {
            Assert.IsFalse(Utils.ConvertToBool("n"));
        }

        [TestMethod]
        public void ConvertToBoolSuccesTrueTest()
        {
            Assert.IsTrue(Utils.ConvertToBool("s"));
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ConvertToBooFailTest()
        {
            Assert.IsTrue(Utils.ConvertToBool("TSIM"));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ConvertToBooFailNullTest()
        {
            Assert.IsTrue(Utils.ConvertToBool(null));
        }
    }
}
