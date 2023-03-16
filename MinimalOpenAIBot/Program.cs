using Azure;
using Azure.AI.OpenAI;
using Azure.Core;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();
builder.Services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();

// Add OpenAI Client
builder.Services.AddSingleton<OpenAIClient>(_ =>
{
    var uri = new Uri(builder.Configuration["OpenAI:Endpoint"]);
    var keyCredential = new AzureKeyCredential(builder.Configuration["OpenAI:Key"]);
    return new OpenAIClient(uri, keyCredential);
});

// Add bot
builder.Services.AddTransient<IBot, OpenAIBot>();

// Build app
var app = builder.Build();

// Define bot handler
var botHandler = (HttpRequest req, HttpResponse res, IBotFrameworkHttpAdapter adapter, IBot bot) =>
{
    adapter.ProcessAsync(req, res, bot);
};

// Map message endpoint
app.MapPost("/api/messages", botHandler);

// Run app
app.Run();
