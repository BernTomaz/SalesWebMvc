using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SalesWebMvcContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("SalesWebMvcContext")));

// registra o seeding service
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SalesRecordService>();

var app = builder.Build();

// aplica migrações e seed em dev
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var ctx = scope.ServiceProvider.GetRequiredService<SalesWebMvcContext>();
    ctx.Database.Migrate(); // garante DB atualizado
    var seeder = scope.ServiceProvider.GetRequiredService<SeedingService>();
    seeder.Seed();          // popula dados (implemente abaixo)
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
