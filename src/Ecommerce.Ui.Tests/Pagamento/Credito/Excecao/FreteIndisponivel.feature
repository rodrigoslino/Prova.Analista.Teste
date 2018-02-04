Feature: Frete indisponível
	Como comprador da Zattini 
	quero selecionar a forma de pagamento como cartão de crédito, 
	preencher meus dados e prosseguir com o processo de compra.

Background: 
	Given Realizar login

@Browser_Chrome
@Browser_Firefox
Scenario: Ao acessar o checkout e os fretes não estiverem disponíveis deve ser apresentado alert, com ação de redirecionar para o carrinho.
	Given eu navego pelo ecommerce
	And clico nos produtos para CASA
	And seleciono o primeiro produto
	And clico em comprar
	When clico em concluir compra
	Then mostrar warning de frete indisponivel
	And clicar em Ok entendi no warning
