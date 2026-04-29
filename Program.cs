using BoardGameRag;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();
    
var apiKey = config["Gemini:ApiKey"];

var builder = Kernel.CreateBuilder();

if (apiKey != null)
    builder.AddGoogleAIGeminiChatCompletion(
        modelId: "gemini-2.5-flash-lite",
        apiKey: apiKey);
var kernel = builder.Build();

var question = "Give me a list of all the rules of the game:" + RulebookReader.ReadRules();
var response = await kernel.InvokePromptAsync(question);
Console.WriteLine($"AI Response: {response}");