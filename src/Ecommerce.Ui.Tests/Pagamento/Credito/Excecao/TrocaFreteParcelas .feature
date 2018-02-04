Feature: Troca de frete e parcelas selecionada
	Como comprador da Zattini 
	quero selecionar a forma de pagamento como cartão de crédito, 
	preencher meus dados e prosseguir com o processo de compra.

Background: 
	Given Realizar login

@Browser_Chrome
@Browser_Firefox
Scenario: Estou com a seleção de frete e já inclui cartão + parcelas quando altero o frete e existe alteração de quantidade de parcelas ou valor das parcelas. 
	Given eu navego pelo ecommerce
	And clico nos produtos para CASA
	And seleciono o primeiro produto
	And clico em comprar
	When clico em concluir compra
	Then visualizar warning
	And clicar em Ok entendi no warning
