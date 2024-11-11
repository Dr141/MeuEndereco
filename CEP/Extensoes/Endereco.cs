using CEP.Modelo;
using CEP.Negocios;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CEP.Extensoes;

public static class Endereco
{
    public static async Task<EnderecoResponse> ObterEndereco(this string numeroCEP)
    {
        try
        {
            numeroCEP.ValidaCEP();
            if(numeroCEP.Length > 8 ) numeroCEP = numeroCEP.Replace("-","");
            return await numeroCEP.BuscarEnderecoAsync();
        }
        catch { throw; }
    }

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
