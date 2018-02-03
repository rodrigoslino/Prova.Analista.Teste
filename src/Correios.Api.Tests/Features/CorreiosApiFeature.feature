Feature: API dos Correrios 
	Utilizando a API dos Correrios
	Eu quero consultar CEPs válidos e inválidos

Scenario Outline: Consultar API dos Correios com cep válido
	Given Eu navego pela API dos Correios com o cep <Cep>
	When eu consulto
	Then o endereço deve ser <Endereco>

Scenarios: 
		| Cep        | Endereco                    |
		| 02945-080  | Rua Fragária Rósea          |
		| 04711-030  | Rua Enxovia                 |
		| 18277-703  | Rua Durvalino Martins 	   |
		| 18277-708  | Rua João Floriano Silveira  |

Scenario Outline: Consultar API dos Correios com cep inválido
	Given Eu navego pela API dos Correios com o cep <Cep>
	When eu consulto
	Then retornado json com erro

Scenarios: 
		| Cep        | Endereco                    |
		| 02945-081  | (Erro)                      |
		| 02945-091  | (Erro)                      |