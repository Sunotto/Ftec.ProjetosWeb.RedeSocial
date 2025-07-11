var builder = WebApplication.CreateBuilder(args);

// Configuração de serviços
builder.Services.AddControllersWithViews(); // Se você usa Razor Views
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSession(); // ou services.AddSession();

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
app.UseSession(); // certifique-se que está no pipeline

// Mapeamento de rotas padrão (MVC)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=SignIn}/{id?}");

// Se tiver apenas Web API (sem views), use só:
app.MapControllers();

app.Run();
