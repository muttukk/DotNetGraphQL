using Microsoft.FeatureManagement;
using SqlAppAzureDB.Data.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = ""; // Get connection from Azure app config -->Access Keys -->Primary key

// to read the config from Azure App config
//builder.Host.ConfigureAppConfiguration(builder =>
// {
//     builder.AddAzureAppConfiguration(connectionString);
// });

// to read the config from Azure App config and also to read the Fature flags
//builder.Host.ConfigureAppConfiguration(builder =>
// {
//     builder.AddAzureAppConfiguration(options=>
//     options.Connect(connectionString).UseFeatureFlags());
// });


// Add services to the container.
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddRazorPages();

// for using Feature flags from Azure resources 
// Add AddFeatureManagement is from Nuget package
// in portal Azure--> Web App--> Feature Manager
// builder.Services.AddFeatureManagement();

// https://learn.microsoft.com/en-us/azure/azure-app-configuration/use-feature-flags-dotnet-core?tabs=core5x FF at controller / action level

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
