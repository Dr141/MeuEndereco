using System.ComponentModel.DataAnnotations;

namespace CEP.Extensoes;
public static class Formata
{
    public static string FormataCEP(this string numeroCEP)
    {
        try
        {
            ValidateCEP(numeroCEP);
            return numeroCEP.Insert(5, "-");
        }
        catch { throw; }
    }

    public static string RemoveFormatacao(
        this string numeroCEP)
    {
        try
        {
            ValidateCEP(numeroCEP, true);
            return numeroCEP.Replace("-", "");
        }
        catch { throw; }
    }

    private static void ValidateCEP(string numeroCEP, bool removeFormatacao = false)
    {
        if (!removeFormatacao)
        {
            var cepAttribute = new StringLengthAttribute(8)
            {
                MinimumLength = 8,
                ErrorMessage = "O CEP deve conter 8 dígitos."
            };
            var regexAttribute = new RegularExpressionAttribute("^[0-9]+$")
            {
                ErrorMessage = "O CEP deve conter apenas números."
            };

            if (!cepAttribute.IsValid(numeroCEP))
            {
                throw new ValidationException(cepAttribute.ErrorMessage);
            }

            if (!regexAttribute.IsValid(numeroCEP))
            {
                throw new ValidationException(regexAttribute.ErrorMessage);
            }
        }
        else
        {
            var regexAttribute = new RegularExpressionAttribute(@"^\d{5}-\d{3}$")
            {
                ErrorMessage = "O CEP deve estar no formato 00000-000."
            };

            if (!regexAttribute.IsValid(numeroCEP))
            {
                throw new ValidationException(regexAttribute.ErrorMessage);
            }
        }
    }
}