using Website.Interfaces;
using Website.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("theBlackbookApiClient", c =>
{
    string theBlackbookHost = builder.Configuration.GetValue<string>("theBlackbookApiHost") ?? string.Empty; c.BaseAddress = new Uri(theBlackbookHost);
    c.BaseAddress = new Uri(theBlackbookHost);
});
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<ISetService, SetService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
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
