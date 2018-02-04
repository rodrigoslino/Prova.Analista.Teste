Feature: Validação de estoque parcial e indisponível juntas
	Como comprador da Zattini 
	quero selecionar a forma de pagamento como cartão de crédito, 
	preencher meus dados e prosseguir com o processo de compra.

Background: 
	Given Realizar login

@Browser_Chrome
@Browser_Firefox
Scenario: Tenho 1 produto ou mais no checkout e 1 produto ficou indisponível parcialmente e 1 produto ficou fora do estoque na ação de finalizar compra.
	Given eu navego pelo ecommerce
	And clico nos produtos para CASA
	And seleciono o primeiro produto
	And clico em comprar
	When clico em concluir compra
	Then mostrar warning avisando que o produto XPTO foi adicionado e tem somente Y qtde disponíveis. E que a quantidade foi atualizada e compilar com a mensagem de erro avisando que o produto XPTO ficou fora de estoque. Para continuar deve ser excluído do carrinho.
	And clicar em Ok entendi no warning
