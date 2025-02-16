using FullStackTask_Web.Configuration;
using FullStackTask_Web.Model;
using FullStackTask_Web.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//AutoMapper
builder.Services.AddAutoMapper(typeof(MapperInitlizer));

//Repository
builder.Services.AddHttpClient();
builder.Services.AddScoped<IRepository<NaseljeDTO>>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new Repository<NaseljeDTO>(httpClientFactory, configuration, "api/naselje");
});

builder.Services.AddScoped<IRepository<DrzavaDTO>>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new Repository<DrzavaDTO>(httpClientFactory, configuration, "api/drzava");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
