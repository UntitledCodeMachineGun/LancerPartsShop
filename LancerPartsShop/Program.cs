using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//ConfigureServices

builder.Services.AddControllersWithViews()
				.AddSessionStateTempDataProvider();

var app = builder.Build();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;

if (environment.IsDevelopment())
{ 
	app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
	endpoints.MapControllerRoute("category", "{controller=Category}/{action=Category}/{id?}");
	endpoints.MapControllerRoute("blog", "{controller=Blog}/{action=Blog}");
	endpoints.MapControllerRoute("post", "{controller=Post}/{action=Post}");
});

//app.MapGet("/", () => "Hello World!");

app.Run();
