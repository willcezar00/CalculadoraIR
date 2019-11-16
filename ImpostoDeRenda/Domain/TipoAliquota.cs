using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoDeRenda.Domain
{
    public class TipoAliquota
    {
        private readonly double minRenda;
        private readonly double maxRenda;
        private readonly double aliquota;

        public static readonly List<TipoAliquota> ALIQUOTAS = new List<TipoAliquota>();
        private TipoAliquota(double minRenda, double maxRenda, double aliquota)
        {
            this.minRenda = minRenda;
            this.maxRenda = maxRenda;
            this.aliquota = aliquota;
            ALIQUOTAS.Add(this);
        }

        public readonly static TipoAliquota ALIQUOTA_NIVEL_0 = new TipoAliquota(0d, 1_903.89, 0d);
        public readonly static TipoAliquota ALIQUOTA_NIVEL_1 = new TipoAliquota(1_903.89d, 2_826.66d, 7.5d);
        public readonly static TipoAliquota ALIQUOTA_NIVEL_2 = new TipoAliquota(2_826.66d, 3_751.06, 15d);
        public readonly static TipoAliquota ALIQUOTA_NIVEL_3 = new TipoAliquota(3_751.06, 4_664.68, 22.5d);
        public readonly static TipoAliquota ALIQUOTA_NIVEL_4 = new TipoAliquota(4_664.68, double.MaxValue, 27.5d);

        public bool IsOnAliquota(double renda)
        {
            return renda >= minRenda && renda < maxRenda;
        }

        public double CalculateAliquota(double renda)
        {
            return renda * aliquota / 100;
        }
    }
}
