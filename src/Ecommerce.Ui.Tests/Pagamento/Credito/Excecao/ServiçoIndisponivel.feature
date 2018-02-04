Feature: Faltou conexão ou serviço indisponível
	Como comprador da Zattini 
	quero selecionar a forma de pagamento como cartão de crédito, 
	preencher meus dados e prosseguir com o processo de compra.

Background: 
	Given Realizar login

@Browser_Chrome
@Browser_Firefox
Scenario: Faltou conexão com a internet
	Given eu navego pelo ecommerce
	And clico nos produtos para CASA
	And seleciono o primeiro produto
	And clico em comprar
	When clico em concluir compra
	Then a internet ficou indisponível
	And clicar em Ok entendi no warning
	And habilitar botão Finalizar compra
