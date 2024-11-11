using CEP.Extensoes;
using System.ComponentModel.DataAnnotations;

namespace CEPTest;

public class FormataTest
{
    private readonly string cepSemFormata = "68540000";
    private readonly string cepFormatado = "68540-000";
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FormataCEP()
    {
        var resultado = cepSemFormata.FormataCEP();
        Assert.That(resultado, Is.EqualTo(cepFormatado));
    }

    [Test]
    public void FormataCEP2()
    {
        var ex = Assert.Throws<ValidationException>(() => Formata.FormataCEP("aaaaa"));
        Assert.That(ex.Message, Is.EqualTo("O CEP deve conter 8 dígitos."));
    }

    [Test]
    public void FormataCEP3()
    {
        var ex = Assert.Throws<ValidationException>(() => Formata.FormataCEP("aaaaabbb"));
        Assert.That(ex.Message, Is.EqualTo("O CEP deve conter apenas números."));
    }

    [Test]
    public void RemoveFormatacaoCEP()
    {
        var resultado = cepFormatado.RemoveFormatacao();
        Assert.That(resultado, Is.EqualTo(cepSemFormata));
    }

    [Test]
    public void RemoveFormatacaoCEP1()
    {
        var ex = Assert.Throws<ValidationException>(() => Formata.RemoveFormatacao("aaaaa"));
        Assert.That(ex.Message, Is.EqualTo("O CEP deve estar no formato 00000-000."));
    }
}