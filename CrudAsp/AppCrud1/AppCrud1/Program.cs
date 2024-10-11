using AppCrud1.Repository;
using AppCrud1.Repository.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adicionando a interface como serviço
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// adicionando a outra interface como serviço 
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
