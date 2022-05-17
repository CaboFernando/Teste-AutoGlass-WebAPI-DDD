# Teste-AutoGlass-WebAPI-DDD
Teste Técnico

- Esse é o repositório do código fonte que tem como objetovo medir o nível técnico em desenvolvimento nas tecnologias presentes:
  * .Net 5
  * Estrutura em camadas
  * DDD
  * ORM
  * Automapper
  * Teste Unitário

- A estrutura da Web API ficou completa, com os endpoints de Produtos, no modelo RESTFul usando os verbos http.

- O Back WebApi segue o padrão Rest, então pode ser consumida a ferramenta integrada Swagger.

- A documentação fica atribuído também ao Swagger incluido no projeto.

- Foi utilizado o migration com EF core, e para criação da base de dados basta rodar os comandos no Package Manager Console no projeto 4 - Infra:
  * Add-Migration CriandoBanco -Context Contexto
  * Update-database -Context Contexto

- Os testes unitários foram feitos em xunit e todos foram aprovados.


No mais é isso, espero que gostem do meu teste.

Att-

Carlos F. Santos.
