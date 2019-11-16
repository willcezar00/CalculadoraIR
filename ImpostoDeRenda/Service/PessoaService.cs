using ImpostoDeRenda.Domain;
using ImpostoDeRenda.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImpostoDeRenda.Service
{
    public class PessoaService
    {
        private static PessoaService instance;

        public  PessoaRepository PessoaRepository {  get; private set; }

        private PessoaService()
        {
            PessoaRepository = PessoaRepository.GetInstance();
        }

        public static PessoaService GetInstance()
        {
            if (instance == null)
            {
                instance = new PessoaService();
            }
            return instance;
        }

        public IList<Pessoa> ReadPessoas(string file)
        {
            return PessoaRepository.ReadAllPerson(file);
        }
    }
}
