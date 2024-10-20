using Agenda.Components;
using Agenda.Data;
using Agenda.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var botToken = builder.Configuration["TelegramSettings:Token"];
var chatId = builder.Configuration["TelegramSettings:ID"];

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<AgendaContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("AgendaContext") ?? throw new InvalidOperationException("Connection string 'AgendaContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddHttpClient<TelegramServices>(client =>
{
    client.BaseAddress = new Uri($"https://api.telegram.org/bot{botToken}/");
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler());

builder.Services.AddSingleton(sp => new TelegramServices(sp.GetRequiredService<HttpClient>(), botToken, chatId));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
    app.UseMigrationsEndPoint();
	app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
