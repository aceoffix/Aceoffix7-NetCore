using AceoffixNetCore.AceServer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Available starting from Aceoffix v7.3.1.1
builder.Services.AddAceoffixAcewServer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.SetIsOriginAllowed(_ => true)
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});


var app = builder.Build();
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseCors("AllowAll");

//Aceoffix configuration is mandatory.
//Note: These two lines of code must be placed before app.UseRouting().
app.UseAceoffixAcewServer();// Available starting from Aceoffix v7.3.1.1
app.UseMiddleware<AceoffixNetCore.AceServer.ServerHandlerMiddleware>();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
