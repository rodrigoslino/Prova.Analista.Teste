using System.Configuration;
using Ecommerce.Ui.Tests.Util;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Ecommerce.Ui.Tests.Login
{
    [Binding]
    public class PrincipalFeatureSteps
    {
        private readonly WebDriver _webDriver;

        public PrincipalFeatureSteps(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [Given(@"eu navego pelo ecommerce")]
        public void GivenEuNavegoPeloEcommerce()
        {
            var driver = _webDriver.Current;
            driver.Manage().Window.Maximize();
            var ecommerceUrlLogin = ConfigurationManager.AppSettings["ecommerceUrl"] +
                                    ConfigurationManager.AppSettings["caminhoLogin"];
            driver.Navigate().GoToUrl(ecommerceUrlLogin);
        }

        [Given(@"preencho o login e senha")]
        public void GivenPreenchoOLoginESenha()
        {
            _webDriver.Wait.Until(d => d.FindElement(By.Id("username")))
                .SendKeys(ConfigurationManager.AppSettings["login"]);

            _webDriver.Wait.Until(d => d.FindElement(By.Id("password")))
                .SendKeys(ConfigurationManager.AppSettings["senha"]);
        }

        [When(@"eu pressiono Acessar Conta")]
        public void WhenEuPressiono()
        {
            _webDriver.Current.FindElement(By.Id("login-button"))
                .Submit();
        }

        [Then(@"login realizado com sucesso")]
        public void ThenLoginRealizadoComSucesso()
        {
            var nomeLogado = _webDriver.Wait
                .Until(ExpectedConditions.ElementIsVisible(
                    By.Id("username-logged")));
            Assert.AreEqual(nomeLogado.Text, ConfigurationManager.AppSettings["nome"]);
        }
        
        [AfterScenario()]
        public void FecharBrowserDepoisDoTeste()
        {
            _webDriver.Quit();
        }
    }
}