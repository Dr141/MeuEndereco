using CEP.Negocios;

namespace CEP.Extensoes;
public static class Formata
{
    public static string FormataCEP(this string numeroCEP)
    {
        try
        {
            numeroCEP.ValidaCEP();
            return numeroCEP.Insert(5, "-");
        }
        catch { throw; }
    }

    public static string RemoveFormatacao(this string numeroCEP)
    {
        try
        {
            numeroCEP.ValidaCEP();
            return numeroCEP.Replace("-", "");
        }
        catch { throw; }
    }
}