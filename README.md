
# API de Gerenciamento de Envio de E-mails com Hangfire

##### Por Kayque Almeida Piton

Este projeto é uma API REST desenvolvida em .NET 8.0 para gerenciar o envio de e-mails utilizando Hangfire para agendamento de tarefas. Inclui operações de agendamento, execução e monitoramento de envios de e-mails.

## Funcionalidades

#### Envio de E-mails
  * Agendamento de envios de e-mails com Hangfire.
  * Gerenciamento de envios recorrentes, únicos ou programados.
  * Tratamento de exceções e falhas nos envios.

#### Dashboard do Hangfire
  * Monitoramento em tempo real de tarefas agendadas.
  * Visualização de jobs ativos, falhados, e executados com sucesso.
  * Controle sobre jobs recorrentes.

## Tecnologias Utilizadas

#### Frameworks Principais
   * .NET 8.0
   * Hangfire 1.8.14
   * Hangfire.SqlServer 1.8.14
   * AutoMapper 13.0.1
   * FluentValidation 11.9.2
   * Refit 7.1.2
   * Swagger com Swashbuckle.AspNetCore 6.6.2

#### Bibliotecas de Apoio e Extensões
   * Microsoft.AspNetCore.OpenApi 8.0.7
   * Microsoft.Extensions.Http 8.0.0

#### Ferramentas de Teste e Cobertura
   * coverlet.collector 6.0.2
   * coverlet.msbuild 6.0.2
   * FluentAssertions 6.12.0
   * Microsoft.NET.Test.Sdk 17.8.0
   * Moq 4.20.70
   * xunit 2.8.1
   * xunit.runner.visualstudio 2.8.0

## Configuração do Projeto 

**1. Clone o repositório:**
   ```sh
   git clone https://github.com/kayquepiton/job-hangfire-backend.git
   ```

**2. Navegue para o diretório do projeto:**
   ```sh
   cd job-hangfire-backend
   ```

**3. Configure a string de conexão para o Hangfire:** `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "Hangfire": "Server=localhost\SQLEXPRESS;Database=Hangfire;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

**4. Restaure as dependências e configure o banco de dados do Hangfire:**
   ```sh
   dotnet restore
   ```

**5. Execute o projeto:**
   ```sh
   dotnet run --project Job.Hangfire.Backend.API
   ```

**6. Acesse o Swagger para testar endpoints:**
   - Abra seu navegador e acesse `https://localhost:{port}/swagger` para explorar e testar os endpoints disponíveis.

**7. Acesse o Dashboard do Hangfire para monitoramento:**
   - Acesse `https://localhost:{port}/hangfire` para visualizar e gerenciar os jobs agendados.

## Endpoints da API

#### Envio de E-mails
   * **POST** /api/emails/send - Agendar o envio de um e-mail.

#### Hangfire Dashboard
   * Acesse `/hangfire` para visualizar e gerenciar os jobs.

### Futuras Implementações
   * Melhorar a interface do usuário para configuração de jobs.
   * Adicionar funcionalidades de monitoramento avançado para os envios de e-mails.

## Contato
   * Kayque Almeida Piton
   * Email: [kayquepiton@gmail.com](mailto:kayquepiton@gmail.com)  
   * LinkedIn: [Kayque Almeida Piton](https://www.linkedin.com/in/kayquepiton/)
