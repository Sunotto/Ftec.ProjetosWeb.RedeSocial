var builder = WebApplication.CreateBuilder(args);

// Configuração de serviços
builder.Services.AddControllersWithViews(); // Se você usa Razor Views
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(); // Serve arquivos de wwwroot/
app.UseRouting();
app.UseAuthorization();

// Mapeamento de rotas padrão (MVC)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Feed}/{action=Feed}/{id?}");

// Se tiver apenas Web API (sem views), use só:
app.MapControllers();

app.Run();
