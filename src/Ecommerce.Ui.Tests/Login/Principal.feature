Feature: Realizar login
	Como comprador da Zattini 
	quero selecionar a forma de pagamento como cartão de crédito, 
	preencher meus dados e prosseguir com o processo de compra.

@Browser_Chrome
@Browser_Firefox
Scenario: Fazer login
	Given eu navego pelo ecommerce
    And preencho o login e senha
	When eu pressiono Acessar Conta
	Then login realizado com sucesso
