using ImpostoDeRenda.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ImpostoDeRenda.Repository
{
    public class RendimentoRepository
    {

        private static RendimentoRepository instance;

        private RendimentoRepository() { }

        public static RendimentoRepository getInstance()
        {
            if (instance == null)
            {
                instance = new RendimentoRepository();
            }
            return instance;
        }

        public Rendimento ReadRendimento(string rendimentoRow)
        {
            try
            {
                string[] tokens = rendimentoRow.Split(Utils.TAB_SEPARATOR);
                double valor = Convert.ToDouble(tokens[0].Trim(), CultureInfo.GetCultureInfo("pt-br"));
                TipoRendimento tipoRendimento = Utils.ConvertToTipoRendimento(tokens[1]);
                return new Rendimento()
                {
                    Tipo = tipoRendimento,
                    Valor = valor
                };
            }
            catch (Exception e)
            {
                throw new ParseRendimentoException(string.Format("Erro! Não foi possível identificar o rendimento na linha {0} .\n Message: {1}", rendimentoRow, e.Message));
            }
        }

        public Rendimento ReadRendimento(StreamReader fileReader)
        {
            return ReadRendimento(fileReader.ReadLine());
        }

        public IList<Rendimento> ReadRendimentos(StreamReader fileReader, int rendimentosCount)
        {
            IList<Rendimento> rendimentos = new List<Rendimento>(rendimentosCount);
            while (rendimentosCount > 0)
            {
                rendimentos.Add(ReadRendimento(fileReader));
                rendimentosCount--;
            }
            return rendimentos;
        }
    }
}
