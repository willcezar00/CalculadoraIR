using ImpostoDeRenda.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImpostoDeRenda.Repository
{
    public class ReportRepository
    {
        private static ReportRepository reportRepository;

        private ReportRepository()
        {

        }

        public static ReportRepository GetInstance()
        {
            if (reportRepository == null)
            {
                reportRepository = new ReportRepository();
            }
            return reportRepository;
        }

        public void WriteReport(IList<ImpostoDeRendaReport> impostoDeRendaReports, string file)
        {
            using (StreamWriter fileWriter = GetStreamWriter(file))
            {
                foreach (var impostoReport in impostoDeRendaReports)
                {
                    fileWriter.WriteLine(string.Format("{0} com CPF - {1} e renda total  R$ {2:0.00} tem retido um total de R$ {3:0.00} devido ao imposto de renda sobre uma renda taxável de R$ {4:0.00}",
                        impostoReport.Pessoa.Nome, impostoReport.Pessoa.CPF, impostoReport.RendaTotal, impostoReport.ImpostoRetido, impostoReport.RendaTaxavel));
                }
            }
        }

        private StreamWriter GetStreamWriter(string file)
        {
            return string.IsNullOrEmpty(file) ? new StreamWriter(Console.OpenStandardOutput()) : new StreamWriter(file);
        }
    }
}
