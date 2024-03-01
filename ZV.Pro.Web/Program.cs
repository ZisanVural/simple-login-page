using Microsoft.EntityFrameworkCore;
using ZV.Pro.Business.Implements;
using ZV.Pro.Business.Interfaces;
using ZV.Pro.Data.Context;
using ZV.Pro.Data.Implements;
using ZV.Pro.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllersWithViews(); //service kullanimi, mvc kullanimini aktif eder
builder.Services.AddTransient<IUserRepository, UserRepository>(); //dependency injection ile nesne bagimliligindan kurtarmak icin kullandigimiz interfacein servis ayarlari
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddDbContext<ApplicationDbContext>(options //veri tabani baglantisi servis ayarlari
=> options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); //middleware yapisi=app.Use
app.UseStaticFiles(); //wwwroot icindeki statik dosyalari kullanmamiza yardimci olur

app.UseRouting(); //routing, gelen istegin hangi contoller hangi actiona gidecegini belirler

app.UseAuthorization(); //kimlik dogrulama islemleri

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}"); //routing 

app.Run(); //islemleri calistirir ve uygulamayi sonlandirir
