Feature: Forma de pagamento: Cartão
	Como comprador da Zattini 
	quero selecionar a forma de pagamento como cartão de crédito, 
	preencher meus dados e prosseguir com o processo de compra.

Background: 
	Given Realizar login

@Browser_Chrome
@Browser_Firefox
Scenario: Validação de campos no pagamento por cartão de crédito
	Given clico nos produtos para CASA
	And seleciono o primeiro produto
	And clico em comprar
	When clico em concluir compra
	Then A opção de cartão de crédito deve apresentar campos para preenchimento dos dados do cartão
	And Número do cartão Aceita somente números
	And Número do cartão mínimo de 16 caracteres
	And Número do cartão Máximo de 19 caracteres
	And Número do cartão Deve existir identificação de bandeira conforme digitação do número
	And Nome do titular Aceita letras e espaços.
	And Nome do titular Mínimo de 3 caracteres.
	And Nome do titular Máximo de 70 caracteres.
	And O nome do titular deve ser sempre composto, ou seja, caso inclua somente 1 nome deve ser marcado como inválido.
	And Data de Validade do cartão Aceita somente números.
	And Data de Validade do cartão com Máscara: DD/MM
	And Data de Validade do cartão Deve ser apresentada lista de meses e anos.
	And Data de Validade do cartão Limites de (01 a 12) para meses e (18 a 48) para anos
	And Código de segurança Aceita somente números.
	And Código de segurança Mínimo de 3 caracteres.
	And Código de segurança Máximo de 4 caracteres.
	And Caso a bandeira informada seja AMEX o CVV deve possuir no mínimo de 4 caracteres.
	And No CVV Para todas as outras bandeiras o mínimo e máximo de caracteres devem ser 3.
	And Opção de Parcelamento O número de parcelas deve ser apresentado automaticamente na página, com a opção de pagamento à vista.
	And Opção de Parcelamento Deve ser apresentada uma lista de parcelas, calculadas de acordo com o valor do pedido. A parcela deverá possuir valor mínimo de R$ 40,00 
	And Opção de Parcelamento A quantidade de parcelas máxima deverá ser 10.
	And Ao clicar no botão de concluir compra e o pedido cair em alguma regra de exceção o cliente irá ver o retorno de alguns dos casos descritos abaixo no painel Caso de exceção.
	And Ao clicar no botão de concluir compra e o pedido for realizado com sucesso o cliente deve visualizar na tela de obrigado o caso de sucesso descrito nessa estória.