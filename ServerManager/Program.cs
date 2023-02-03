using ServerManager.Api;
using ServerManager.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

new ServiceRegister(configuration, builder.Services).Register();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});
new ApiRouter(app).SetRouting();
app.Run();