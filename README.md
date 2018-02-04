# Prova Anaslita de Teste

- Respostas:

Exercício 1: O plano seria separar cada projeto com seus módulos e tipos de testes(teste integrado, teste unitário, teste de aceitação, teste de interface e etc).
A ferramenta "Jenkins" por exemplo possui uma API e através de um projeto particular é possível desenvolver uma interface executando todos os testes, após commits enviados ao repositório, após a publicação de uma nova versão do sistema ou até mesmo a execução manual.
![alt text](https://github.com/rodrigoslino/Prova.Analista.Teste/blob/da5a99aac287c422918e6da813738313dc8f0854/src/Ci.png)

Exercício 2 e 3: Entrar na pasta "src" e abrir o arquivo "Prova.Analista.Teste.sln" no visual sutdio 2015. Lá dentro existirá o projeto "Ecommerce.Ui.Tests".
Obs. Ler o readme do projeto. (link para readme: https://github.com/rodrigoslino/Prova.Analista.Teste/blob/master/src/Ecommerce.Ui.Tests/README.md)

Segue imagem abaixo de apenas uma parte do Report do projeto de teste fron-end.
![alt text](https://github.com/rodrigoslino/Prova.Analista.Teste/blob/master/src/Ecommerce.Ui.Tests/Report.png)

Exercício 4: Entrar na pasta "src" e abrir o arquivo "Prova.Analista.Teste.sln" no visual sutdio 2015. Lá dentro existirá o projeto "Correios.Api.Tests".
Obs. Ler o readme do projeto.
(link para readme: https://github.com/rodrigoslino/Prova.Analista.Teste/blob/master/src/Correios.Api.Tests/README.md)

Exercício 5: Utilizaria o próprio Report do Specflow e personalizaria conforme fosse a necessidade.

Segue imagem de exemplo abaixo do Report completo do projeto para Api dos Correios do exercício 4.
![alt text](https://github.com/rodrigoslino/Prova.Analista.Teste/blob/master/src/Correios.Api.Tests/Report.png)

Exercício 6:
Criaria um projeto para cada tipo de integração e cada projeto com seus módulos separados em pastas.
Nos testes seriam realizados verificações de performance, regras de negócio, especificações técnicas, retorno de erros, transações SQL, nomes das propriedades, comportamentos esperados e etc.
Por exemplo, para transações SQL poderia ser utilizado uma réplica da estrutura do banco de dados com as tabelas vazias e executar as integrações apontando para este novo e assim que tudo fosse executado, seria dado um Rollback para apenas testar os sistemas em desenvolvimento.
Outro exemplo, seria executar as integrações e checar todas as regras de negócios.

Exercício 7: A forma mais simples seria acessar múltiplas threads para simular chamadas de requisições. Será preciso um supercomputador ou um cloud com load balance para estressar o sistema conforme a necessidade. 
Os testes irão fazer requisições a estes sistemas com o objetivo de quantificar o número de Exceptions Vs. o número de requisições.
Deve ser reportado através de gráficos, número de requisições, falhas e tempo médio de resposta.

Exercício 8:
Com a evolução da tecnologia ao longo dos anos, é percebido um crescimento enorme de dados para as empresas.
A análise desses dados irá gerar dúvidas em relação a qualidade do dado e dos resultados.
Num futuro próximo será necessário realizar um processo ETL em diversos sistemas, mas para manter a qualidade dos dados é preciso ter diversos tipos de testes.
Para atender as novas necessidades do mercado é fundamental estar sempre atualizado e comprovar atraves de cases de sucesso as novas tecnologias e soluções a serem utilizadas.
As habilidades nesse novo contexto serão principalmente experiencias em bancos de dados relacional e não relacional, conhecimento na regra de negócios, programar em diversas linguagens, frameworks (exemplo: Hadoop, Apache Spark, MapReduce e etc), algebra, matemática e etc.