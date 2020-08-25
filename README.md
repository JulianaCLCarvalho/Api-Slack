## Desafio Automação de teste de API - RestSharp

- Arquitetura Projeto
	- Linguagem		- [CSharp](https://docs.microsoft.com/pt-br/dotnet/csharp/ "CSharp")
	- Orquestrador de testes - [NUnit 3.12](https://github.com/nunit/nunit "NUnit 3.12")
	- Relatório de testes automatizados - [ExtentReports 4.0.3](http://extentreports.com/docs/versions/4/net/ "ExtentReports 4.0.3")
	- Framework interação com API - [Rest Sharp 106.6.10](http://restsharp.org/ "RestSharp 106.6.10") 

## Metas

- [x]	1) Implementar 50 scripts de testes que manipulem uma aplicação cuja interface é uma API REST. 
Todos os testes podem ser vistos na pasta testes e nas respectivas subpastas: 

```
Channels
Chat
Groups
Team
Users
```
 
- [x]	2) Alguns scripts devem ler dados de uma planilha Excel para implementar Data-Driven.
É possível verificar ao acessar as  respectivas classes: 
`CompartilharMensagemCanalTests.cs` com o método `DadosValidos(ArrayList testData)`;
`EnviarMensagemCanalTests.cs` método `DadosValidos()`.

- [x]	3) O projeto deve tratar autenticação. Exemplo: OAuth2.

A aplicação de API do Slack, exige autenticação via API Token, a qual é gerada diretamente pela interface do sistema https://api.slack.com , pelo menu 
`Documentation/legacy/custom-integrations/legacy-tokens.`Depois de gerado, o token foi utilizado em todos os testes, sendo fornecido no `Authorization`
no request como atributo Header da solicitação.

- [x]	4) Pelo menos um teste deve fazer a validação usando REGEX (Expressões Regulares).
Foi utilizado o método de asserção `StringAssert.IsMatch()` na Classe `CompartilharMensagemCanalTests.cs` método `DadosValidos()`e também na classe `EnviarMensagemCanalTests.cs` método `DadosValidos()`.

- [x]	5) O projeto deverá gerar um relatório de testes automaticamente.
O relatório sempre será gerado na pasta raiz do projeto dependendo do ambiente em que o projeto é executado.
```
 \bin\Debug\Reports,
 \bin\Release\Reports,
 \bin\Desenv\Reports ou
 \bin\Prod\Reports 
```
- [x]	6) Implementar pelo menos dois ambientes (desenvolvimento / homologação).
Foi gerado as configurações dos ambientes seguindo as orientações do @saymowan [multi-environments-visualstudio](https://github.com/saymowan/multi-environments-visualstudio) .
 Os arquivos encontram-se na raiz do projeto `app.desenv.config` e `app.prod.config`.

- [x]	7) A massa de testes deve ser preparada neste projeto, seja com scripts carregando massa nova no BD ou com restore de banco de dados.
Para cumprir essa meta foi criado o projeto Desafio Mantis Api. Veja a descrição:(https://gitlab.com/julianacarvalho/desafiomantisapi)

- [x]	8) Executar testes em paralelo. Pelo menos duas threads (25 testes cada).
Foi utilizado atributo do NUnit para paralelizar a execução dos testes, inserindo nos testes a chave `[Parallelizable]` juntamente das chaves que marcam os métodos como teste `[Test]`.
E as Theads de execução dentro do Arquivo `AssemblyInfo.cs` em `[assembly: LevelOfParallelism(2)]`.

- [x]	9)Testes deverão ser agendados pelo Jenkins, CircleCI, TFS ou outra ferramenta de CI que preferir.
A integração Contínua foi feita através do Jenkins usando repositório GitLab conforme descrito em: [GitLab + Jenkins: uma integração poderosa](https://imasters.com.br/devsecops/gitlab-jenkins-uma-integracao-poderosa).
As configurações de etapas do build foram feitas conforme orientações do @saymowan [multi-environments-visualstudio](https://github.com/saymowan/docker-mariadb-seleniumgrid-IC-POM) .


