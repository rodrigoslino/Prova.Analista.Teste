# Ecommerce.Ui.Tests
Exercício 2 e 3 - Cenários de testes e scripts de automação de testes para front-end para a www.zattini.com.br.

1. Lista de tecnologias, patterns e frameworks usados:

• Tecnologias
  -	Visual Studio 2015 enterprise
  -	Resharper
  -	Specflow
  
• Patterns
  -	BDD
  - Module pattern (por pastas)
  
• Frameworks
  - C# .NET Framework 4.5.2
  -	NUnit 3.9.0 - Utilizado apenas os "Assert" para verificações na consulta
  -	SpecFlow 2.1.0 - Utilizado para criar o cenários
  -	SpecRun.Runner 1.5.2 - Utilizado para rodar os cenários no Visual Studio
  -	SpecRun.SpecFlow 1.5.2 - Utilizado para documentar o cenários
  - Selenium.Chrome.WebDriver 2.35 - Driver do chrome para ser utilizado no Selenium
  - Selenium.Firefox.WebDriver 0.19.1 - Driver do firefox para ser utilizado no Selenium
  - Selenium.WebDriver 3.8.0 - Automação de testes
  - Selenium.Support 3.8.0 - Automação de testes

2. Estratégia utilizada:
  - Em cada teste, é feito o login, em seguida é limpo seu carrinho e depois realizado o teste em questão.

3. Observações:
  - Cada teste possui para 2 browsers (Chrome e Firefox)
  - Abrir no Visual Studio ou executar o cmd "runtests.cmd" para executar os testes
  - Utilizado login contido no "app.config" para todos os testes
  - Não foram criados todos o testes possíveis
  