using Ftec.ProjetosWeb.RedeSocial.Aplicacao;
using Ftec.ProjetosWeb.RedeSocial.Dominio.Repositorio;
using Ftec.ProjetosWeb.RedeSocial.Repositorio;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// 1. Adiciona serviços MVC
builder.Services.AddControllers();

// 2. Configura o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Corrige conflitos de nomes duplicados (como enums com mesmo nome)
    c.CustomSchemaIds(type => type.FullName);

    // Inclui os comentários XML no Swagger (pega o nome do .xml baseado no projeto)
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// 3. Registra repositórios com string de conexão
builder.Services.AddScoped<IComentariosRepository>(sp =>
    new ComentariosRepositorio(
        builder.Configuration.GetConnectionString("conexao")
    )
);

builder.Services.AddScoped<ICurtidasRepository>(sp =>
    new CurtidasRepositorio(
        builder.Configuration.GetConnectionString("conexao")
    )
);

builder.Services.AddScoped<ComentariosAplicacao>();
builder.Services.AddScoped<CurtidasAplicacao>();


var app = builder.Build();

// 4. Usa Swagger no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty; // Swagger na raiz do projeto
    });
}

// 5. Middleware padrão
app.UseAuthorization();
app.MapControllers();
app.Run();
