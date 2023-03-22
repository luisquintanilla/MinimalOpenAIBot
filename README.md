# Minimal OpenAI Bot

Sample Bot built with Bot Framework, ASP.NET Minimal APIs, and Azure OpenAI Service

![image](https://user-images.githubusercontent.com/46974588/227020840-0ccf4378-a237-42fd-87f2-916f0aad7920.png)

## Prerequisites

- [Azure Subscription](https://aka.ms/free)
- [Azure OpenAI Service](https://learn.microsoft.com/azure/cognitive-services/openai/how-to/create-resource?pivots=web-portal)
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Bot Framework Emulator](https://github.com/Microsoft/BotFramework-Emulator/releases/tag/v4.14.1)

## Run 

1. Create or update your *appsettings.json* file with the following content:

    ```json
    "OpenAI": {
      "Endpoint": "<YOUR-AZURE-OPEN-AI-ENDPOINT>",
      "Key": "<YOUR-AZURE-OPEN-AI-KEY>",
      "Deployment": "<YOUR-AZURE-OPEN-AI-DEPLOYMENT-NAME>"
    }
    ```

1. Run the application

    - **Visual Studio:** Open Solution and press <kbd>F5</kbd>
    - **In the CLI:** Navigate to the MinimalOpenAIBot project and enter the following into the command line: `dotnet run`
  
1. Start Bot Framework Emulator and enter the URL of your bot endpoint (i.e. *http://localhost:<PORT>/api/messages*).
1. Start chatting with your bot.
