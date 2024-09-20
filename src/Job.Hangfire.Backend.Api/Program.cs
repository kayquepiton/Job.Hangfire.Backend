using System.Reflection;
using Hangfire;
using Hangfire.SqlServer;
using Job.Hangfire.Backend.API.Middlewares;
using Job.Hangfire.Backend.Application.Mappings;
using Job.Hangfire.Backend.Infra.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configura o pipeline de requisições HTTP.
ConfigureMiddleware(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Adiciona controllers ao container de serviços
    services.AddControllers();

    // Configura as opções de comportamento da API
    services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true; // Suprime a validação automática do estado do modelo
    });

    // Adiciona AutoMapper ao container com o perfil especificado
    services.AddAutoMapper(typeof(MappingProfile));

    // Configuração do Hangfire com SQL Server
    services.AddHangfire(config => config
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(configuration.GetConnectionString("Hangfire"), new SqlServerStorageOptions
        {
            PrepareSchemaIfNecessary = true, // Permite que o Hangfire crie o banco se ele não existir
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true
        }));

    // Adiciona o servidor do Hangfire
    services.AddHangfireServer();

    // Adiciona serviços para exploração de endpoints da API e configuração do Swagger/OpenAPI
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "API de Gerenciamento de Envio de E-mails com Hangfire .NET 8",
            Version = "v1",
            Description = "Este projeto é uma API REST desenvolvida em .NET 8.0 para gerenciar o envio de e-mails utilizando Hangfire para agendamento de tarefas.",
            Contact = new OpenApiContact
            {
                Name = "Kayque Almeida Piton",
                Email = "kayquepiton@gmail.com",
                Url = new Uri("https://github.com/kayquepiton")
            }
        });

        // Configura os comentários XML para o Swagger
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    });

    // Configura as dependências da aplicação
    services.ConfigureAppDependencies(configuration);

    // Adiciona o HttpClient ao container
    services.AddHttpClient();
}

void ConfigureMiddleware(WebApplication app)
{
    // Habilita o Swagger no ambiente de desenvolvimento
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = string.Empty; // Define o Swagger UI na raiz do app
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Gerenciamento de Envio de E-mails com Hangfire .NET 8");
        });
    }

    // Adiciona middleware de tratamento de exceções personalizado
    app.UseMiddleware<ExceptionMiddleware>();

    // Adiciona o painel do Hangfire
    app.UseHangfireDashboard("/hangfire");

    // Tarefa para testar o Hangfire
    // Tarefa recorrente que executa a cada minuto
    RecurringJob.AddOrUpdate(
        "tarefa-exemplo",
        () => Console.WriteLine("Executando uma tarefa recorrente!"),
        Cron.Minutely);

    // Tarefa que executa apenas uma vez
    BackgroundJob.Enqueue(() => Console.WriteLine("Executando uma tarefa única!"));

    // Adiciona middleware de roteamento
    app.UseRouting();

    // Redireciona requisições HTTP para HTTPS
    app.UseHttpsRedirection();

    // Mapeia os controllers com rotas de atributos
    app.MapControllers();
}
