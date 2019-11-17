using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoDeRenda.Domain
{
    public class ImpostoDeRendaReport
    {
        public Pessoa Pessoa { get; set; }
        public double ImpostoRetido { get; set; }
        public double RendaTotal { get; set; }
        public double RendaTaxavel { get; set; }
    }
}
