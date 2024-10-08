using InterfaceDAL;
using InterfacesLL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using CookUp_Companion_BusinessLogic.Manager;
using DAL;
using CookUp_Companion_BusinessLogic.InterfacesLL;
using CookUp_Companion_BusinessLogic.Algoritam;
using CookUp_Companion_BusinessLogic.Managers;
using CookUp_Companion_BusinessLogic.InterfacesDal;
using CookUp_Companion_Classes;
using DAL.DAL;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configure authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Login");
        options.LogoutPath = new PathString("/LogOut");
        options.AccessDeniedPath = new PathString("/Login");
    });


builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<IUserDALManager, UserDal>();
builder.Services.AddTransient<IRecipeManager, RecipeManager>();
builder.Services.AddTransient<IRecipeDALManager, RecipeDal>();
//builder.Services.AddTransient<IRecommendedRecipesAlgoritam, RecommendedRecipesAlgoritam>();
builder.Services.AddTransient<IRecommendedRecipesAlgoritam, RecommendedRecipesByOtherUsersLikes>();
builder.Services.AddTransient<IPlannerManager, PlannerManager>();
builder.Services.AddTransient<IPlannerDALManager, PlannerDal>();
builder.Services.AddTransient<IShoppingCartManager, ShoppingCartManager>();
builder.Services.AddTransient<IShoppingCartDALManager, ShoppingCartDal>();
builder.Services.AddTransient<IRecipeReviewsManager, RecipeReviewManager>();
builder.Services.AddTransient<IRecipeReviewsDALManager, RecipeReviewDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


// Add authentication middleware
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
