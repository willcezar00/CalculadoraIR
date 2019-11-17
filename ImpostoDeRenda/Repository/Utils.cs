using ImpostoDeRenda.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ImpostoDeRenda.Repository
{
    public static class Utils
    {
        public static readonly char TAB_SEPARATOR = '\t';

        private readonly static Dictionary<string, TipoRendimento> TIPO_RENDIMENTO_BY_STRING_VALUE =
            new Dictionary<string, TipoRendimento>()
        {
            { "APOSENTADORIA", TipoRendimento.APOSENTADORIA },
            { "OUTROS", TipoRendimento.OUTROS },
            { "PENSAO", TipoRendimento.PENSAO },
            { "REFORMA", TipoRendimento.REFORMA },
            { "SALARIO", TipoRendimento.SALARIO }
        };

        private readonly static Dictionary<string, bool> BOOL_BY_STRING_VALUE =
            new Dictionary<string, bool>()
        {
            { "Y", true },
            { "S", true },
            { "N", false }
        };

        public static TipoRendimento ConvertToTipoRendimento(string tipoRendimento)
        {
            string tipoRendimentoUpper = RemoveDiacritics(tipoRendimento.Trim()).ToUpper();
            if (!TIPO_RENDIMENTO_BY_STRING_VALUE.ContainsKey(tipoRendimentoUpper))
            {
                throw new Exception(string.Format("Não foi possível encontrar rendimento do tipo {0}", tipoRendimento));
            }
            return TIPO_RENDIMENTO_BY_STRING_VALUE[tipoRendimentoUpper];
        }

        public static bool ConvertToBool(string value)
        {
            value = value.Trim();
            string realValue = value.Length > 0 ? value.Substring(0, 1).ToUpper() : "";
            if (!BOOL_BY_STRING_VALUE.ContainsKey(realValue))
            {
                throw new Exception(string.Format("Não foi possível encontrar bool para a string {0}", value));
            }
            return BOOL_BY_STRING_VALUE[realValue];
        }

        public  static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
