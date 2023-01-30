using LancerPartsShop.Domain;
using LancerPartsShop.Domain.Repositories.Abstract;
using LancerPartsShop.Domain.Repositories.EntityFramework;
using LancerPartsShop.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//ConfigureServices

//Admin area policy setup
builder.Services.AddAuthorization(x =>
{
	x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

builder.Services.AddControllersWithViews(x => 
{
	x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
}).AddSessionStateTempDataProvider();

//connect functional of app as services
builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
builder.Services.AddTransient<IBlogItemRepository, EFBlogRepository>();
builder.Services.AddTransient<ICategoryRepository, EFCategoryRepository>();
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
builder.Services.AddTransient<DataManager>();

//Connect configuration from appsettings.json
builder.Configuration.Bind("Project", new Config());
//DBContext connection
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));


//Identity setup
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
	opts.User.RequireUniqueEmail = true;
	opts.Password.RequiredLength = 6;
	opts.Password.RequireNonAlphanumeric = false;
	opts.Password.RequireLowercase = false;
	opts.Password.RequireUppercase = false;
	opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//Cookie setup
builder.Services.ConfigureApplicationCookie(opts =>
{
	opts.Cookie.Name = "LPartsAuth";
	opts.Cookie.HttpOnly = true;
	opts.LoginPath = "/account/login";
	opts.AccessDeniedPath = "/account/accessdenied";
	opts.SlidingExpiration = true;
});

var app = builder.Build();

IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;


if (environment.IsDevelopment())
{ 
	app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}");
	endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
	endpoints.MapControllerRoute("category", "{controller=Category}/{action=Category}/{id?}");
	endpoints.MapControllerRoute("blog", "{controller=Blog}/{action=Blog}/{id?}");
	endpoints.MapControllerRoute("post", "{controller=Post}/{action=Post}/{id?}");
	endpoints.MapControllerRoute("contacts", "{controller=Contacts}/{action=Contacts}");
});

//app.MapGet("/", () => "Hello World!");

app.Run();
