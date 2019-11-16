using ImpostoDeRenda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImpostoDeRenda.Service
{
    public class RendimentoService
    {
        private static RendimentoService instance;
        private static readonly ISet<TipoRendimento> RENDIMENTOS_TAXAVEIS = new HashSet<TipoRendimento>
        {
            TipoRendimento.OUTROS,
            TipoRendimento.SALARIO
        };

        private RendimentoService()
        {

        }

        public static RendimentoService GetInstance()
        {
            if (instance == null)
            {
                instance = new RendimentoService();
            }
            return instance;
        }

        public double FindTotalRendimentoTaxavel(IList<Rendimento> rendimentos)
        {
            return FindTotalRendimentoTotal(rendimentos.Where(rendimento => IsRendimentoTaxavel(rendimento)));
        }

        public double FindTotalRendimentoTotal(IEnumerable<Rendimento> rendimentos)
        {
            return rendimentos.Aggregate(0d, (acumulador, rendimento) => acumulador + rendimento.Valor);
        }

        public TipoAliquota FindTipoAliquota(Pessoa pessoa)
        {
            if (pessoa.EnfermidadeGrave)
            {
                return TipoAliquota.ALIQUOTA_NIVEL_0;
            }
            var renda = FindTotalRendimentoTaxavel(pessoa.Rendimentos);
            return TipoAliquota.ALIQUOTAS.Where(aliquota => aliquota.IsOnAliquota(renda)).First();
        }

        public double GetImpostoRetido(Pessoa pessoa)
        {
            return FindTipoAliquota(pessoa).CalculateAliquota(FindTotalRendimentoTaxavel(pessoa.Rendimentos));
        }

        public bool IsRendimentoTaxavel(Rendimento rendimento)
        {
            return RENDIMENTOS_TAXAVEIS.Contains(rendimento.Tipo);
        }



    }
}
