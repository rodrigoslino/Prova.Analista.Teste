# Correios.Api.Tests
Exercício 4 - Consulta de CEPs válidos e inválidos na Api dos Correios

1. Lista de tecnologias, patterns e frameworks usados:

• Tecnologias
  -	Visual Studio 2015 enterprise
  -	Resharper
  -	Specflow
  
• Patterns
  -	BDD
  
• Frameworks
  - C# .NET Framework 4.5.2
  -	Newtonsoft.Json 8.0.3 - Utilizado para serialização e deserialização de Json
  -	NUnit 3.9.0 - Utilizado apenas os "Assert" para verificações na consulta
  -	SpecFlow 2.1.0 - Utilizado para criar o cenários
  -	SpecRun.Runner 1.5.2 - Utilizado para rodar os cenários no Visual Studio
  -	SpecRun.SpecFlow 1.5.2 - Utilizado para documentar o cenários
  
2. Sequencia de processos para consulta do cep:
  - Consultar cep pela URL https://viacep.com.br/ws/{0}/json/ via webclient
  - Ler o Json de retorno
  - Comparar com o retorno esperado
  