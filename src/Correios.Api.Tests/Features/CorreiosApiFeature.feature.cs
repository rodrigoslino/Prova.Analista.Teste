﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Correios.Api.Tests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("API dos Correrios", Description="\tUtilizando a API dos Correrios\r\n\tEu quero consultar CEPs válidos e inválidos", SourceFile="Features\\CorreiosApiFeature.feature", SourceLine=0)]
    public partial class APIDosCorreriosFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CorreiosApiFeature.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "API dos Correrios", "\tUtilizando a API dos Correrios\r\n\tEu quero consultar CEPs válidos e inválidos", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void ConsultarAPIDosCorreiosComCepValido(string cep, string endereco, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Consultar API dos Correios com cep válido", exampleTags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given(string.Format("Eu navego pela API dos Correios com o cep {0}", cep), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.When("eu consulto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
 testRunner.Then(string.Format("o endereço deve ser {0}", endereco), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Consultar API dos Correios com cep válido, 02945-080", SourceLine=11)]
        public virtual void ConsultarAPIDosCorreiosComCepValido_02945_080()
        {
            this.ConsultarAPIDosCorreiosComCepValido("02945-080", "Rua Fragária Rósea", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Consultar API dos Correios com cep válido, 04711-030", SourceLine=11)]
        public virtual void ConsultarAPIDosCorreiosComCepValido_04711_030()
        {
            this.ConsultarAPIDosCorreiosComCepValido("04711-030", "Rua Enxovia", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Consultar API dos Correios com cep válido, 18277-703", SourceLine=11)]
        public virtual void ConsultarAPIDosCorreiosComCepValido_18277_703()
        {
            this.ConsultarAPIDosCorreiosComCepValido("18277-703", "Rua Durvalino Martins", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Consultar API dos Correios com cep válido, 18277-708", SourceLine=11)]
        public virtual void ConsultarAPIDosCorreiosComCepValido_18277_708()
        {
            this.ConsultarAPIDosCorreiosComCepValido("18277-708", "Rua João Floriano Silveira", ((string[])(null)));
#line hidden
        }
        
        public virtual void ConsultarAPIDosCorreiosComCepInvalido(string cep, string endereco, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Consultar API dos Correios com cep inválido", exampleTags);
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given(string.Format("Eu navego pela API dos Correios com o cep {0}", cep), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.When("eu consulto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("retornado json com erro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Consultar API dos Correios com cep inválido, 02945-081", SourceLine=23)]
        public virtual void ConsultarAPIDosCorreiosComCepInvalido_02945_081()
        {
            this.ConsultarAPIDosCorreiosComCepInvalido("02945-081", "(Erro)", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Consultar API dos Correios com cep inválido, 02945-091", SourceLine=23)]
        public virtual void ConsultarAPIDosCorreiosComCepInvalido_02945_091()
        {
            this.ConsultarAPIDosCorreiosComCepInvalido("02945-091", "(Erro)", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
