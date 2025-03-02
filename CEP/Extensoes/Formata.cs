using CEP.Negocios;

namespace CEP.Extensoes;

/// <summary>
/// Classe responsável por formatar o CEP.
/// </summary>
public static class Formata
{
    /// <summary>
    /// Método responsável por formata o número do CEP para o padrão 00000-000.
    /// </summary>
    /// <param name="numeroCEP">O parâmetro espera uma <see cref="string"/> com números com 8 dígitos.</param>
    /// <returns>
    /// O método retorna uma <see cref="string"/> com o CEP no seguinte formato: 00000-000.
    /// </returns>
    public static string FormataCEP(this string numeroCEP)
    {
        try
        {
            numeroCEP.ValidaCEP();
            return Convert.ToUInt64(numeroCEP).ToString("00000\\-000");
        }
        catch { throw; }
    }

    /// <summary>
    /// Método responsável por remover a formatação no número do CEP.
    /// </summary>
    /// <param name="numeroCEP">O parâmetro espera uma <see cref="string"/> com o seguinte formato 00000-000.</param>
    /// <returns>
    /// O método retorna uma <see cref="string"/> com o CEP no seguinte formato: 00000000.
    /// </returns>
    public static string RemoveFormatacao(this string numeroCEP)
    {
        try
        {
            numeroCEP.ValidaCEP();
            string apenasNumeros = string.Empty;

            for (int i = 0; i < numeroCEP.Length; i++)
            {
                if(char.IsDigit(numeroCEP[i]))
                    apenasNumeros += numeroCEP[i];
            }

            return apenasNumeros;
        }
        catch { throw; }
    }
}
