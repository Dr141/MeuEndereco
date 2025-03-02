using System.ComponentModel.DataAnnotations;

namespace CEP.Negocios;

/// <summary>
/// Classe responsável por realizar validações no CEP.
/// </summary>
internal static class Validacoes
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="numeroCEP"></param>
    /// <exception cref="ValidationException"></exception>
    internal static void ValidaCEP(this string numeroCEP)
    {
        StringLengthAttribute cepAttribute = new StringLengthAttribute(8)
        {
            MinimumLength = 8,
            ErrorMessage = "O CEP deve conter 8 dígitos."
        };

        RegularExpressionAttribute regexAttribute = new RegularExpressionAttribute("^[0-9]+$")
        {
            ErrorMessage = "O CEP deve conter apenas números."
        };        

        if (!cepAttribute.IsValid(numeroCEP) && numeroCEP.Length <= 8)
        {
            throw new ValidationException(cepAttribute.ErrorMessage);
        }

        if (!regexAttribute.IsValid(numeroCEP) && numeroCEP.Length <= 8)
        {
            throw new ValidationException(regexAttribute.ErrorMessage);
        }

        regexAttribute = new RegularExpressionAttribute(@"^\d{5}-\d{3}$")
        {
            ErrorMessage = "O CEP deve estar no formato 00000-000."
        };

        if (!regexAttribute.IsValid(numeroCEP) && numeroCEP.Length > 8)
        {
            throw new ValidationException(regexAttribute.ErrorMessage);
        }
    }
}
