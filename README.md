# Usuario API

Esta API foi desenvolvida utilizando ASP.NET Core 8 e segue a arquitetura DDD para implementar um CRUD de usuario, utilizando autenticação JWT. 
Conta também com mensageria para envio de email (rabbitmq), interfaces e injeção de dependência para facilitar a manutenção e testabilidade do código.

## Estrutura do Projeto

A estrutura do projeto é organizada da seguinte forma:

- **/src**
  - **/Api**: Contém os controllers e configurações da API.
  - **/Application**: Lógica de aplicação, serviços e mapeamento de DTOs.
  - **/Domain**: Modelos de domínio, entidades.
  - **/Infrastructure**: Implementação de infraestrutura, acesso a dados e autenticação.
  - **/Tests**: Testes unitários utilizando XUnit.

## Tecnologias e Ferramentas utilizada
- 
- DDD (Domain Driven Design): Metodologia de desenvolvimento que enfatiza a modelagem do domínio.
- Teste de Integração: Utilização de testes para garantir a integridade e funcionalidade da aplicação.
- API Rest, Swagger: Implementação de uma API RESTful documentada com Swagger para facilitar o entendimento e teste da API.
- EntityFramework: Framework ORM para mapeamento objeto-relacional.
- Injeção de Dependência + Inversão de Controle: Princípios de design que facilitam a manutenção e testabilidade do código.
- JWT (JSON Web Token): Mecanismo de autenticação para proteger as rotas da API.
- Bogus: Biblioteca para geração de dados fictícios para testes.
- Unit of Work: Padrão de projeto para gerenciar transações.
- Integração com APIs Externas: Capacidade de integrar-se a outras APIs externas para enriquecer os dados ou funcionalidades.
- Injeção de Dependência: Técnica para fornecer dependências externas a um componente de forma desacoplada.

### Requisitos

- ASP.NET Core 8 SDK
- Banco de dados SQL Server

### Configuração do envio de email

1. Configure a string de conexão com o banco de dados no arquivo `appsettings.json`.
2. Execute as migrações para criar o esquema do banco de dados:
 - dotnet ef database update
