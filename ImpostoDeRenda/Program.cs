using ImpostoDeRenda.Service;
using System;
using System.IO;

namespace ImpostoDeRenda
{
    class Program
    {
        private PessoaService pessoaService;
        private ReportService reportService;

        public Program()
        {
            pessoaService = PessoaService.GetInstance();
            reportService = ReportService.GetInstance();
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            string inputPath = args.Length > 0 ? args[0] : null;
            string outputPath = args.Length > 1 ? args[1] : null;
            var pessoas = program.pessoaService.ReadPessoas(inputPath);
            var reports = program.reportService.GerarReport(pessoas);
            program.reportService.WriteReport(reports, outputPath);
        }
    }

}
