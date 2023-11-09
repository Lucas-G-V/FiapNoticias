# API de Notícias em .NET

Esta é uma API de Notícias construída em .NET usando o Entity Framework para a persistência de dados. A aplicação possui funcionalidades de autenticação e autorização para controlar o acesso aos recursos.

## Funcionalidades

- **Notícias:** Permite a criação, leitura, atualização e exclusão de notícias.

## Tecnologias Utilizadas

- .NET Core
- Entity Framework
- Azure (Container Registry, Container Instance)
- GitHub Actions

## Configuração

### Pré-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) (ou editor de texto de sua escolha)

### Configuração da Base de Dados

1. Abra o Visual Studio e conecte-se ao banco de dados usando as configurações do Entity Framework.
2. Execute as migrações para criar o esquema do banco de dados.

```bash
dotnet ef database update
```
## Testes

A aplicação foi desenvolvida seguindo práticas de desenvolvimento seguro e inclui:

- Testes de Integração
- Testes de Unidade (xUnit)

Para executar os testes, certifique-se de ter a configuração de conexão correta em `appsettings.Testing.json`. Em seguida, utilize o comando:

```bash
dotnet test
```
## Observação
O banco de teste é criado automaticamente utilizando o Github Actions através do docker. Caso seja necessário testar na sua máquina, lembre-se de mudar a Connection String do Banco, no arquivo appsettings.Testing.json
