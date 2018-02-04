Feature: EnderecoDeEntrega
    Como comprador da Zattini 
	quero selecionar a forma de pagamento como cartão de crédito, 
	preencher meus dados e prosseguir com o processo de compra.

Background: 
	Given Realizar login

@Browser_Chrome
@Browser_Firefox
Scenario: Na primeira compra do cliente o endereço demonstrado é o 
preenchido no cadastro do cliente
	Given clico nos produtos para CASA
	And seleciono o primeiro produto
	And clico em comprar
	When clico em concluir compra
	Then o endereço deve ser 'Rua Fragária Rósea, 399'

@Browser_Chrome
@Browser_Firefox
Scenario: Na segunda ou demais compras o endereço demonstrado é o 
utilizado da última compra
	Given clico nos produtos para CASA
	And seleciono o primeiro produto
	And clico em comprar
	When clico em concluir compra
	Then o endereço deve ser 'Rua Fragária Rósea, 399'

@Browser_Chrome
@Browser_Firefox
Scenario: Deve existir uma opção de alterar o endereço de entrega para todos os clientes
	Given clico nos produtos para CASA
	And seleciono o primeiro produto
	And clico em comprar
	When clico em concluir compra
	Then deve existir um botão de alterar endereço
	And visualizar listagem de endereços diferentes 
	And opção de cadastrar novo endereço de entrega
	And ao trocar o endereço nas telas secundárias o endereço deve ser atualizado automaticamente na tela do one page checkout