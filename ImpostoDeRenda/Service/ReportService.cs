using ImpostoDeRenda.Domain;
using ImpostoDeRenda.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImpostoDeRenda.Service
{
    public class ReportService
    {
        private static ReportService instance;

        public RendimentoService RendimentoService { get; private set; }
        public ReportRepository ReportRepository { get; private set; }

        private ReportService()
        {
            ReportRepository = ReportRepository.GetInstance();
            RendimentoService = RendimentoService.GetInstance();
        }

        public static ReportService GetInstance()
        {
            if (instance == null)
            {
                instance = new ReportService();
            }
            return instance;
        }

        public IList<ImpostoDeRendaReport> GerarReport(IList<Pessoa> pessoas)
        {
            return pessoas.Select(pessoa => new ImpostoDeRendaReport
            {
                Pessoa = pessoa,
                ImpostoRetido = RendimentoService.GetImpostoRetido(pessoa),
                RendaTaxavel = RendimentoService.FindTotalRendimentoTaxavel(pessoa.Rendimentos),
                RendaTotal = RendimentoService.FindTotalRendimentoTotal(pessoa.Rendimentos)
            }).ToList();
        }

        public void WriteReport(IList<ImpostoDeRendaReport> impostoDeRendaReports, string file)
        {
            ReportRepository.WriteReport(impostoDeRendaReports,file);
        }
    }
}
