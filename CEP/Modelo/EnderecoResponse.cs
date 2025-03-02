namespace CEP.Modelo;

/// <summary>
/// Classe modelo de retorno da API.
/// </summary>
public class EnderecoResponse
{
    public string cep { get; set; }
    public string? logradouro { get; set; }
    public string? complemento { get; set; }
    public string? unidade { get; set; }
    public string? bairro { get; set; }
    public string? localidade { get; set; }
    public string? uf { get; set; }
    public string? estado { get; set; }
    public string? regiao { get; set; }
    public string? ibge { get; set; }
    public string? gia { get; set; }
    public string? ddd { get; set; }
    public string? siafi { get; set; }

    public EnderecoResponse(string pcep)
    {
        cep = pcep;
    }

    public EnderecoResponse()
    {
        
    }
}