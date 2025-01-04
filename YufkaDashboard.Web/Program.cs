using Shared.Context;
using System.Data.SqlClient;
using System.Data;
using YufkaDashboard.Business.Abstract;
using YufkaDashboard.Business.Concrete;
using YufkaDashboard.DataAccess.Abstract;
using YufkaDashboard.DataAccess.Conrete;
using Microsoft.Extensions.FileProviders;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
#region Session
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(1440);//temp 2 default 60
	options.Cookie.HttpOnly = false;
	options.Cookie.IsEssential = true;
});
#endregion

builder.Services.AddScoped<IProductBusiness,ProductBusiness>();
builder.Services.AddScoped<IProductDal, ProductDal>();
builder.Services.AddScoped<IFinanceBusiness,FinanceBusiness>();
builder.Services.AddScoped<IFinanceDal, FinanceDal>();
builder.Services.AddScoped<IAuthBussiness,AuthBussiness>();
builder.Services.AddScoped<IAuthDal, AuthDal>();
builder.Services.AddScoped<IDocumentBusiness, DocumentBusiness>();
builder.Services.AddScoped<IDocumentDal, DocumentDal>();
builder.Services.AddScoped<IHomeBusiness, HomeBusiness>();
builder.Services.AddScoped<IHomeDal, HomeDal>();
builder.Services.AddScoped<ISystemBusiness, SystemBusiness>();
builder.Services.AddScoped<ISystemDal, SystemDal>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<Context>();
var cultureInfo = new CultureInfo("tr-TR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

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
//My Computer
//app.UseStaticFiles(new StaticFileOptions
//{
//	FileProvider = new PhysicalFileProvider("C:\\Users\\simse\\source\\repos\\YufkaDashboard\\YufkaDashboard\\YufkaDashboard.Web\\wwwroot\\Documents\\"),
//	RequestPath = "/Documents"
//});
//Bussiness Computer
//app.UseStaticFiles(new StaticFileOptions
//{
//	FileProvider = new PhysicalFileProvider("C:\\Users\\simse\\source\\repos\\ShopManagement\\YufkaDashboard.Web\\wwwroot"),
//	RequestPath = "/Documents"
//});
//Product
//app.UseStaticFiles(new StaticFileOptions
//{
//	FileProvider = new PhysicalFileProvider("C:\\Inetpub\\vhosts\\ozkaradenizyufka.tr\\httpdocs\\wwwroot\\Documents"),
//	RequestPath = "/Documents"
//});
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Auth}/{action=Index}/{id?}");
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
