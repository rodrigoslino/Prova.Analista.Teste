Feature: desconto e parcelas
	Como comprador da Zattini 
	quero selecionar a forma de pagamento como cartão de crédito, 
	preencher meus dados e prosseguir com o processo de compra.

Background: 
	Given Realizar login

@Browser_Chrome
@Browser_Firefox
Scenario: Desconto aplicado no checkout quando realizado a ação de finalizar compra e o desconto não é mais aplicável a compra.
	Given eu navego pelo ecommerce
	And clico nos produtos para CASA
	And seleciono o primeiro produto
	And clico em comprar
	When clico em concluir compra
	Then visualizar um warning informando que houve uma alteração de preço e que o cliente deve conferir antes de finalizar a compra
