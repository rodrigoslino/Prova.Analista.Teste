Feature: Frete 
	Como comprador da Zattini 
	quero selecionar a forma de pagamento como cartão de crédito, 
	preencher meus dados e prosseguir com o processo de compra.

Background: 
	Given Realizar login

@Browser_Chrome
@Browser_Firefox
Scenario: As opções de frete
	Given eu navego pelo ecommerce
	And clico nos produtos para CASA
	And seleciono o primeiro produto
	And clico em comprar
	When clico em concluir compra
	Then devem existir as opções: 'Normal,Agendada,Expressa,Super Expressam,Super Esportiva'
	And a seleção automática do frete é realizada pelo frete mais barato
	And as opções de frete Super Expressa e Super Esportiva não devem ter a opção de pagamento por Boleto Bancário.