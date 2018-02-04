Feature: Estoque Total
	Como comprador da Zattini 
	quero selecionar a forma de pagamento como cartão de crédito, 
	preencher meus dados e prosseguir com o processo de compra.

Background: 
	Given Realizar login

@Browser_Chrome
@Browser_Firefox
Scenario: Tenho 1 produto ou mais no checkout e 1 produto ficou fora de estoque na ação de finalizar compra.
	Given eu navego pelo ecommerce
	And clico nos produtos para CASA
	And seleciono o primeiro produto
	And clico em comprar
	When clico em concluir compra
	Then mostrar mensagem de erro avisando que o produto XPTO ficou indisponível. Para continuar ele deve voltar ao carrinho e excluir o produto.
	And clicar em Ok entendi no warning
