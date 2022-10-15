using Uno.Wasm.Bootstrap.Server;
using UnoTeamsApp.Interop.TeamsSDK;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddTeamsFx(builder.Configuration.GetSection("TeamsFx"));
builder.Services.AddScoped<MicrosoftTeams>();

builder.Services.AddControllers();
builder.Services.AddHttpClient("WebClient", client => client.Timeout = TimeSpan.FromSeconds(600));
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseUnoFrameworkFiles();
app.MapFallbackToFile("index.html");
app.UseEndpoints(endpoints =>
{
    
    //endpoints.MapBlazorHub();
    //endpoints.MapFallbackToPage("/_Host");
    endpoints.MapControllers();
});

app.Run();

