using Ftec.ProjetosWeb.RedeSocial.Filters;

var builder = WebApplication.CreateBuilder(args);

// ✅ Adiciona o filtro de exceção ANTES de builder.Build()
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<CustomExceptionFilter>(); // Aqui você usa o nome do filtro
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ⚠️ UseStaticFiles antes de routing

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
