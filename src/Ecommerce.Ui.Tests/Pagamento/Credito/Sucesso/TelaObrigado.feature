Feature: Tela Obrigado - concluir um pedido
	Como comprador da Zattini 
	quero selecionar a forma de pagamento como cartão de crédito, 
	preencher meus dados e prosseguir com o processo de compra.

Background: 
	Given Realizar login

@Browser_Chrome
@Browser_Firefox
Scenario: Ao concluir um pedido com sucesso com cartão de crédito visulizar dados
	Given eu navego pelo ecommerce
	And clico nos produtos para CASA
	And seleciono o primeiro produto
	And clico em comprar
	When clico em concluir compra
	Then visualizo o Número do pedido
	And visualizo email utilizado na compra
	And visualizoInformações sobre a entrega do pedido
