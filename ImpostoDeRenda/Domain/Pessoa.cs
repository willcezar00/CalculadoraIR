using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoDeRenda.Domain
{
    public class Pessoa
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public bool EnfermidadeGrave { get; set; }
        public IList<Rendimento> Rendimentos { get; set; } 

    }
}
