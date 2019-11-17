using ImpostoDeRenda.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImpostoDeRendaTeste.Domain
{
    [TestClass]
    public class TipoAliquotaTest
    {
        [TestMethod]
        public void IsOnAliquotaSuccessTest()
        {
            var renda = 2000d;
            var tipoAliquota = TipoAliquota.ALIQUOTAS.Where(aliquota => aliquota.IsOnAliquota(renda)).First();
            Assert.AreEqual(TipoAliquota.ALIQUOTA_NIVEL_1, tipoAliquota);
        }

        [TestMethod]
        public void IsOnAliquotaFailTest()
        {
            var renda = 3000d;
            var tipoAliquota = TipoAliquota.ALIQUOTAS.Where(aliquota => aliquota.IsOnAliquota(renda)).First();
            Assert.AreNotEqual(TipoAliquota.ALIQUOTA_NIVEL_1, tipoAliquota);
        }

        [TestMethod]
        public void IsOCalculateAliquotanAliquotaSuccessTest()
        {
            var renda = 3000d;
            var impostoRetido = TipoAliquota.ALIQUOTAS.Where(aliquota => aliquota.IsOnAliquota(renda)).First();
            Assert.IsTrue(impostoRetido.IsOnAliquota(renda));
        }

        [TestMethod]
        public void IsOCalculateAliquotanAliquotaFailTest()
        {
            var renda = 2000d;
            var impostoRetido = TipoAliquota.ALIQUOTAS.Where(aliquota => aliquota.IsOnAliquota(renda)).First();
            Assert.IsFalse(impostoRetido.IsOnAliquota(3000d));
        }
    }
}
