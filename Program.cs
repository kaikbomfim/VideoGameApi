using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGameApi.Data;
using DotNetEnv;

// Carrega variáveis de ambiente do arquivo .env para desenvolvimento local
// Permite manter senhas e configurações sensíveis fora do código
Env.Load();

// Cria o builder da aplicação web
var builder = WebApplication.CreateBuilder(args);

// === CONFIGURAÇÃO DE SERVIÇOS ===

// Adiciona suporte a controladores MVC/Web API
builder.Services.AddControllers();

// Configura OpenAPI/Swagger para documentação da API
builder.Services.AddOpenApi();

// Configura o Entity Framework com SQL Server
builder.Services.AddDbContext<VideoGameDbContext>(options => 
{
    // Obtém a string de conexão do appsettings.json
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    
    // Substitui placeholder pela senha real da variável de ambiente
    var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
    connectionString = connectionString?.Replace("${DB_PASSWORD}", dbPassword);
    
    // Configura o provedor SQL Server
    options.UseSqlServer(connectionString);
});

// Constrói a aplicação
var app = builder.Build();

// === CONFIGURAÇÃO DO PIPELINE HTTP ===

// Em ambiente de desenvolvimento, habilita documentação da API
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(); // Interface moderna para documentação usando Scalar
    app.MapOpenApi();            // Endpoint OpenAPI/Swagger
}

// Força redirecionamento para HTTPS
app.UseHttpsRedirection();

// Habilita autorização (mesmo sem implementação específica)
app.UseAuthorization();

// Mapeia os controladores para responder às rotas
app.MapControllers();

// Inicia a aplicação
app.Run();
