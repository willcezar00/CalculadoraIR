using ImpostoDeRenda.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImpostoDeRenda.Repository
{
    public class PessoaRepository
    {

        private static PessoaRepository instance;
        public RendimentoRepository RendimentoRepository { get; private set; }

        private PessoaRepository()
        {
            RendimentoRepository = RendimentoRepository.getInstance();
        }

        public static PessoaRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new PessoaRepository();
            }
            return instance;
        }

        public IList<Pessoa> ReadAllPerson(string file)
        {
            var pessoas = new List<Pessoa>();

            using (StreamReader fileReader = GetStreamReader(file))
            {
                string fileLine;
                while ((fileLine = fileReader.ReadLine()) != null)
                {
                    try
                    {
                        string[] tokens = fileLine.Split(Utils.TAB_SEPARATOR);
                        var rendimentosCount = Convert.ToInt32(tokens[3].Trim());
                        pessoas.Add(new Pessoa
                        {
                            CPF = tokens[0].Trim(),
                            Nome = tokens[1].Trim(),
                            EnfermidadeGrave = Utils.ConvertToBool(tokens[2]),
                            Rendimentos = RendimentoRepository.ReadRendimentos(fileReader, rendimentosCount)
                        });
                    }
                    catch (Exception e)
                    {
                        throw new Exception(string.Format("Erro! Não foi possível ler a linha {0}.\n Message : {1} ", fileLine, e.Message));
                    }

                }
                fileReader.Close();
            }
            return pessoas;
        }

        private StreamReader GetStreamReader(string file)
        {
            return string.IsNullOrEmpty(file) ? new StreamReader(Console.OpenStandardInput()) : new StreamReader(file);
        }
    }
}

