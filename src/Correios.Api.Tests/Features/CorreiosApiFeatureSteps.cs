using System;
using System.Configuration;
using System.Net;
using System.Text;
using Correios.Api.Tests.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Correios.Api.Tests.Features
{
    /// <summary>
    ///     Steps para consulta de CEPs válidos e inválidos na Api dos Correios
    /// </summary>
    [Binding]
    public class CorreiosApiFeatureSteps
    {
        private CorreiosJsonModel _retornoCorreios;
        private string _stringJson;

        [Given(@"Eu navego pela API dos Correios com o cep (.*)")]
        public void GivenEuNavegoPelaApiDosCorreiosComOCep(string cep)
        {
            var correiosApiUrl = string.Format(ConfigurationManager.AppSettings["correiosApiUrl"], cep);
            var webClient = new WebClient { Encoding = Encoding.UTF8 };
            _stringJson = webClient.DownloadString(correiosApiUrl);
        }

        [When(@"eu consulto")]
        public void WhenEuConsulto()
        {
            try
            {
                _retornoCorreios = JsonConvert.DeserializeObject<CorreiosJsonModel>(_stringJson);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        [Then(@"o endereço deve ser (.*)")]
        public void ThenOEnderecoDeveSerEndereco(string endereco)
        {
            Assert.AreEqual(_retornoCorreios.Logradouro, endereco);
        }

        [Then(@"retornado json com erro")]
        public void ThenRetornadoJsonComErro()
        {
            Assert.AreEqual(_retornoCorreios?.Logradouro, null);
        }
    }
}