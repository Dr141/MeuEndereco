# MeuEndereco

O projeto **MeuEndereco** é uma biblioteca que facilita a manipulação e consulta de CEPs, oferecendo funcionalidades para:

- Consultar o endereço completo a partir de um CEP.
- Formatar CEP no padrão brasileiro.
- Remover formatação de CEP.

---

## Funcionalidades

✅ Consulta de endereço por CEP.  
✅ Formatação de CEP no padrão 00000-000.  
✅ Remoção da formatação de CEP (00000-000 ➡️ 00000000).

---

## Classes e Métodos

### Endereco
Classe responsável por consultar o CEP e obter o endereço completo.

#### Métodos

##### `ObterEndereco(string numeroCEP)`

Consulta o endereço correspondente ao CEP informado.

- **Parâmetro**: 
    - `numeroCEP` - Uma `string` contendo o CEP, nos formatos `00000000` ou `00000-000`.
- **Retorno**: 
    - `Task<EnderecoResponse>` - Um objeto contendo as informações do endereço.
- **Exceções**: 
    - Pode lançar exceções em caso de CEP inválido ou falha na consulta ao serviço externo.

---

### Formata
Classe responsável por formatar e desformatar CEPs.

#### Métodos

##### `FormataCEP(string numeroCEP)`

Formata um CEP para o padrão `00000-000`.

- **Parâmetro**: 
    - `numeroCEP` - Uma `string` contendo 8 dígitos.
- **Retorno**: 
    - `string` - CEP formatado no padrão `00000-000`.

##### `RemoveFormatacao(string numeroCEP)`

Remove a formatação de um CEP, deixando apenas os números.

- **Parâmetro**: 
    - `numeroCEP` - Uma `string` no formato `00000-000`.
- **Retorno**: 
    - `string` - CEP sem formatação (`00000000`).

---

## Exemplo de Uso

```csharp
using CEP.Extensoes;

public class Exemplo
{
    public async Task ConsultarCEPAsync()
    {
        string cep = "01001-000";

        // Remover formatação, se necessário
        string cepSemFormatacao = cep.RemoveFormatacao();

        // Obter endereço
        var endereco = await cepSemFormatacao.ObterEndereco();
        Console.WriteLine($"Logradouro: {endereco.Logradouro}, Cidade: {endereco.Localidade}");

        // Formatar novamente, se necessário
        string cepFormatado = cepSemFormatacao.FormataCEP();
        Console.WriteLine($"CEP formatado: {cepFormatado}");
    }
}
