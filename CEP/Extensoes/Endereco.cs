using CEP.Modelo;
using CEP.Negocios;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CEP.Extensoes;

public static class Endereco
{
    /// <summary>
    /// Método responsável por obter o endereço referente ao CEP.
    /// </summary>
    /// <param name="numeroCEP">
    /// O parâmetro espera uma <see cref="string"/> com números com um dos seguintes formato 00000000 ou 00000-000.
    /// </param>
    /// <returns>
    /// O método retorna um objeto do tipo <see cref="EnderecoResponse"/>, com informações referentes ao CEP.
    /// </returns>
    public static async Task<EnderecoResponse> ObterEndereco(this string numeroCEP)
    {
        try
        {
            numeroCEP.ValidaCEP();
            if(numeroCEP.Length > 8 ) numeroCEP = numeroCEP.RemoveFormatacao();
            return await numeroCEP.BuscarEnderecoAsync();
        }
        catch { throw; }
    }

    /// <summary>
    /// Método responsável por consumir API.
    /// </summary>
    /// <param name="numeroCEP">O parâmetro aguardo um valor do tipo <see cref="string"/></param>
    /// <returns>O método retorna uma <see cref="Task"/> do tipo <see cref="EnderecoResponse"/>.</returns>
    private static async Task<EnderecoResponse> BuscarEnderecoAsync(this string numeroCEP) 
    {
        try
        {
            EnderecoResponse enderecoResponse = new EnderecoResponse(numeroCEP);
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("https://viacep.com.br/ws/"),
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync($"{numeroCEP}/json/");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<EnderecoResponse>() ?? enderecoResponse;
            }
            return enderecoResponse;
        }
        catch { throw; }
    }
}
