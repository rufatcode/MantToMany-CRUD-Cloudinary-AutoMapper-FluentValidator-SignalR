using Lab10_FrontToBack;
using Lab10_FrontToBack.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Registarion(builder.Configuration);
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
//app.UseSession();
//app.UseRouting();
//StripeConfiguration.ApiKey = config.GetSection("Stripe:Secret_key").Get<string>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}"
    );

app.Run();

