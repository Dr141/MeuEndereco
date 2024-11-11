using CEP.Extensoes;

namespace CEPTest;

public class EnderecoTest
{
    private readonly string cepSemFormata = "68540000";
    private readonly string cepFormatado = "68540-000";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task ObterEnderecoTesteAsync()
    {
        var endereco = await cepSemFormata.ObterEndereco();
        Assert.That(endereco is not null);
    }

    [Test]
    public async Task ObterEnderecoTeste1Async()
    {
        var endereco = await cepFormatado.ObterEndereco();
        Assert.That(endereco is not null);
    }
}
