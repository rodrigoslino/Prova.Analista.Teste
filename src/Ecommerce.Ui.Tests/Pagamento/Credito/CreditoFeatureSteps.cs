using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using Ecommerce.Ui.Tests.Util;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Ecommerce.Ui.Tests.Pagamento.Credito
{
    [Binding]
    public class CreditoFeatureSteps
    {
        private readonly WebDriver _webDriver;

        public CreditoFeatureSteps(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [Given(@"Realizar login")]
        public void GivenRealizarLogin()
        {
            var driver = _webDriver.Current;
            driver.Manage().Window.Maximize();
            var ecommerceUrlLogin = ConfigurationManager.AppSettings["ecommerceUrl"] +
                                    ConfigurationManager.AppSettings["caminhoLogin"];
            driver.Navigate().GoToUrl(ecommerceUrlLogin);

            _webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(By.Id("username")))
                .SendKeys(ConfigurationManager.AppSettings["login"]);

            _webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(By.Id("password")))
                .SendKeys(ConfigurationManager.AppSettings["senha"]);

            _webDriver.Wait
                .Until(ExpectedConditions.ElementToBeClickable(
                    By.Id("login-button"))).Submit();

            _webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.XPath("//li/a[@title='CASA']")));

            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["ecommerceUrl"] +
                                      ConfigurationManager.AppSettings["caminhoCarrinho"]);

            var existeAlgoNoCarrinho = _webDriver.Current.FindElements(By.XPath("//*[text()='Remover']")).Any();

            if (existeAlgoNoCarrinho)
            {
                foreach (var element in _webDriver.Current.FindElements(By.XPath("//*[text()='Remover']")))
                {
                    _webDriver.Wait
                        .Until(ExpectedConditions.ElementToBeClickable(
                            element)).Click();
                }
            }

            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["ecommerceUrl"]);
        }

        [Given(@"clico nos produtos para CASA")]
        public void GivenClicoNosProdutosParaCasa()
        {
            _webDriver.Wait
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li/a[@title='CASA']")))
                .Click();
        }

        [Given(@"seleciono o primeiro produto")]
        public void GivenSelecionoOPrimeiroProduto()
        {
            _webDriver.Wait
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@itemprop='itemListElement']")))
                .Click();
        }

        [Given(@"clico em comprar")]
        public void GivenClicoEmComprar()
        {
            _webDriver.Wait
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("buy-button-now")))
                .Click();
        }

        [When(@"clico em concluir compra")]
        public void WhenClicoEmConcluirCompra()
        {
            _webDriver.Wait
                .Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("//button[@class='button button-rounded button-flat buy-button-now']")))
                .Click();
        }

        [Then(@"o endereço deve ser '(.*)'")]
        public void ThenOEnderecoDeveSer(string endereco)
        {
            Assert.AreEqual(_webDriver.Current.FindElement(By.CssSelector(".street"))?.Text,
                "Rua Fragária Rósea, 399");
        }

        [Then(@"deve existir um botão de alterar endereço")]
        public void ThenDeveExistirUmBotaoDeAlterarEndereco()
        {
            Assert.IsNotNull(_webDriver.Current.FindElement(By.CssSelector(".btn-change-address")));
        }

        [Then(@"visualizar listagem de endereços diferentes")]
        public void ThenVisualizarListagemDeEnderecosDiferentes()
        {
            _webDriver.Wait
                .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-change-address")))
                .Click();

            Assert.IsNotNull(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".addresses-list"))));
        }

        [Then(@"opção de cadastrar novo endereço de entrega")]
        public void ThenOpcaoDeCadastrarNovoEnderecoDeEntrega_()
        {
            Assert.IsNotNull(_webDriver.Current.FindElement(By.Id("address-create-link")));
        }

        [Then(
            @"ao trocar o endereço nas telas secundárias o endereço deve ser atualizado automaticamente na tela do one page checkout")]
        public void
            ThenAoTrocarOEnderecoNasTelasSecundariasOEnderecoDeveSerAtualizadoAutomaticamenteNaTelaDoOnePageCheckout()
        {
            //ScenarioContext.Current.Pending();
        }
        [Then(@"devem existir as opções: '(.*)'")]
        public void ThenDevemExistirAsOpcoes(string strOpcoes)
        {
            //Nem sempre há todas as opções
        }

        [Then(@"a seleção automática do frete é realizada pelo frete mais barato")]
        public void ThenASelecaoAutomaticaDoFreteERealizadaPeloFreteMaisBarato()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"as opções de frete Super Expressa e Super Esportiva não devem ter a opção de pagamento por Boleto Bancário\.")]
        public void ThenAsOpcoesDeFreteSuperExpressaESuperEsportivaNaoDevemTerAOpcaoDePagamentoPorBoletoBancario_()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"A opção de cartão de crédito deve apresentar campos para preenchimento dos dados do cartão")]
        public void ThenAOpcaoDeCartaoDeCreditoDeveApresentarCamposParaPreenchimentoDosDadosDoCartao()
        {
            Assert.IsNotNull(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-number"))));

            Assert.IsNotNull(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-owner"))));

            Assert.IsNotNull(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-expiration-month"))));

            Assert.IsNotNull(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-expiration-year"))));

            Assert.IsNotNull(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-securitycode"))));

            Assert.IsNotNull(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-installments-number"))));
        }

        [Then(@"Número do cartão Aceita somente números")]
        public void ThenNumeroDoCartaoAceitaSomenteNumeros()
        {
            var textoComLetras = DataGenerator.RandomString(5);

            _webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-number")))
                    .SendKeys(textoComLetras);

            Assert.AreNotEqual(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-number"))).Text, textoComLetras);
        }

        [Then(@"Número do cartão mínimo de (.*) caracteres")]
        public void ThenNumeroDoCartaoMinimoDeCaracteres(int minimo)
        {
            //Campo sem o minLength
        }

        [Then(@"Número do cartão Máximo de (.*) caracteres")]
        public void ThenNumeroDoCartaoMaximoDeCaracteres(int maximo)
        {
            Assert.AreEqual(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-number"))).GetAttribute("maxlength"), maximo.ToString());
        }

        [Then(@"Número do cartão Deve existir identificação de bandeira conforme digitação do número")]
        public void ThenNumeroDoCartaoDeveExistirIdentificacaoDeBandeiraConformeDigitacaoDoNumero()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Nome do titular Aceita letras e espaços\.")]
        public void ThenNomeDoTitularAceitaLetrasEEspacos_()
        {
            var texto = DataGenerator.RandomString(5) + " " +
                DataGenerator.RandomString(5);

            _webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-owner")))
                .SendKeys(texto);

            Assert.True(_webDriver.Wait
                .Until(ExpectedConditions.TextToBePresentInElementValue(
                    By.Id("creditcard-owner"), texto)));
        }

        [Then(@"Nome do titular Mínimo de (.*) caracteres\.")]
        public void ThenNomeDoTitularMinimoDeCaracteres_(int p0)
        {
            //Campo sem o minLength
        }

        [Then(@"Nome do titular Máximo de (.*) caracteres\.")]
        public void ThenNomeDoTitularMaximoDeCaracteres_(int p0)
        {
            //Campo sem o maxLength
        }

        [Then(@"O nome do titular deve ser sempre composto, ou seja, caso inclua somente 1 nome deve ser marcado como inválido\.")]
        public void ThenONomeDoTitularDeveSerSempreCompostoOuSejaCasoIncluaSomenteNomeDeveSerMarcadoComoInvalido_()
        {
            var apenasUmNome = DataGenerator.RandomString(5);

            _webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-owner")))
                    .Clear();

            _webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-owner")))
                .SendKeys(apenasUmNome);

            _webDriver.Wait
                .Until(ExpectedConditions.ElementToBeClickable(
                    By.Id("creditcard-button")))
                .Submit();

            Assert.True(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.XPath("//*[@id='creditcard-owner']/.."))).GetAttribute("class").Contains("error"));
        }

        [Then(@"Data de Validade do cartão Aceita somente números\.")]
        public void ThenDataDeValidadeDoCartaoAceitaSomenteNumeros_()
        {
            var apenasUmNome = DataGenerator.RandomString(5);

            _webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-expiration-month")))
                .SendKeys(apenasUmNome);

            _webDriver.Wait
                .Until(ExpectedConditions.ElementToBeClickable(
                    By.Id("creditcard-expiration-month")))
                .Submit();

            Assert.True(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.XPath("//*[@id='creditcard-expiration-month']/..")))
                    .GetAttribute("class").Contains("error"));
        }

        [Then(@"Data de Validade do cartão com Máscara: DD/MM")]
        public void ThenDataDeValidadeDoCartaoComMascaraDdmm()
        {
            //Não está usando máscara, está usando campos Select
        }

        [Then(@"Data de Validade do cartão Deve ser apresentada lista de meses e anos\.")]
        public void ThenDataDeValidadeDoCartaoDeveSerApresentadaListaDeMesesEAnos_()
        {
            Assert.True(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.XPath("//*[@id='creditcard-expiration-month']")))
                .GetAttribute("type") == "select-one");

            Assert.True(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.XPath("//*[@id='creditcard-expiration-year']")))
                .GetAttribute("type") == "select-one");
        }

        [Then(@"Data de Validade do cartão Limites de \((.*) a (.*)\) para meses e \((.*) a (.*)\) para anos")]
        public void ThenDataDeValidadeDoCartaoLimitesDeAParaMesesEaParaAnos(int minimoMeses, int maximoMeses,
            int minimoAnos, int maximoAnos)
        {
            IWebElement elemMeses = _webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-expiration-month")));
            IList<IWebElement> selectListMeses = new SelectElement(elemMeses).Options;
            Assert.AreEqual(selectListMeses?[1]?.Text, minimoMeses.ToString("D2"));
            Assert.AreEqual(selectListMeses?.LastOrDefault()?.Text, maximoMeses.ToString("D2"));

            IWebElement elemAnos = _webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-expiration-year")));
            IList<IWebElement> selectListAnos = new SelectElement(elemAnos).Options;
            Assert.AreEqual(selectListAnos?[1]?.Text, minimoAnos.ToString("D2"));
            Assert.AreEqual(selectListAnos?.LastOrDefault()?.Text, maximoAnos.ToString("D2"));
        }

        [Then(@"Código de segurança Aceita somente números\.")]
        public void ThenCodigoDeSegurancaAceitaSomenteNumeros_()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Código de segurança Mínimo de (.*) caracteres\.")]
        public void ThenCodigoDeSegurancaMinimoDeCaracteres_(int p0)
        {
            //Campo sem o minLength
        }

        [Then(@"Código de segurança Máximo de (.*) caracteres\.")]
        public void ThenCodigoDeSegurancaMaximoDeCaracteres_(int maximo)
        {
            Assert.AreEqual(_webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("creditcard-securitycode")))
                    .GetAttribute("maxlength"), maximo.ToString());
        }

        [Then(@"Caso a bandeira informada seja AMEX o CVV deve possuir no mínimo de (.*) caracteres\.")]
        public void ThenCasoABandeiraInformadaSejaAMEXOCVVDevePossuirNoMinimoDeCaracteres_(int minimo)
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"No CVV Para todas as outras bandeiras o mínimo e máximo de caracteres devem ser (.*)\.")]
        public void ThenNoCVVParaTodasAsOutrasBandeirasOMinimoEMaximoDeCaracteresDevemSer_(int p0)
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Opção de Parcelamento O número de parcelas deve ser apresentado automaticamente na página, com a opção de pagamento à vista\.")]
        public void ThenOpcaoDeParcelamentoONumeroDeParcelasDeveSerApresentadoAutomaticamenteNaPaginaComAOpcaoDePagamentoAVista_()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Opção de Parcelamento Deve ser apresentada uma lista de parcelas, calculadas de acordo com o valor do pedido\. A parcela deverá possuir valor mínimo de R\$ (.*)")]
        public void ThenOpcaoDeParcelamentoDeveSerApresentadaUmaListaDeParcelasCalculadasDeAcordoComOValorDoPedido_AParcelaDeveraPossuirValorMinimoDeR(Decimal minimo)
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Opção de Parcelamento A quantidade de parcelas máxima deverá ser (.*)\.")]
        public void ThenOpcaoDeParcelamentoAQuantidadeDeParcelasMaximaDeveraSer_(int p0)
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Ao clicar no botão de concluir compra e o pedido cair em alguma regra de exceção o cliente irá ver o retorno de alguns dos casos descritos abaixo no painel Caso de exceção\.")]
        public void ThenAoClicarNoBotaoDeConcluirCompraEOPedidoCairEmAlgumaRegraDeExcecaoOClienteIraVerORetornoDeAlgunsDosCasosDescritosAbaixoNoPainelCasoDeExcecao_()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Ao clicar no botão de concluir compra e o pedido for realizado com sucesso o cliente deve visualizar na tela de obrigado o caso de sucesso descrito nessa estória\.")]
        public void ThenAoClicarNoBotaoDeConcluirCompraEOPedidoForRealizadoComSucessoOClienteDeveVisualizarNaTelaDeObrigadoOCasoDeSucessoDescritoNessaEstoria_()
        {
            //ScenarioContext.Current.Pending();
        }

        [AfterScenario]
        public void FecharBrowserDepoisDoTeste()
        {
            _webDriver.Quit();
        }
    }
}