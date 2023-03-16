using Azure.AI.OpenAI;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
// Bot
class OpenAIBot : ActivityHandler
{
    private readonly OpenAIClient _oaiClient;
    private readonly IConfiguration _config;
    public OpenAIBot(OpenAIClient client, IConfiguration config)
    {
        _oaiClient = client;
        _config = config;
    }

    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
    {
        var completionOptions = new CompletionsOptions()
        {
            Prompt = { turnContext.Activity.Text },
            MaxTokens = 512
        };

        var isNull = _oaiClient == null;

        Completions completions = await _oaiClient.GetCompletionsAsync(_config["OpenAI:Deployment"], completionOptions);
        var replyText = completions.Choices[0].Text;
        await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
    }

    protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
    {
        var welcomeText = "Hello and welcome!";
        foreach (var member in membersAdded)
        {
            if (member.Id != turnContext.Activity.Recipient.Id)
            {
                await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
            }
        }
    }
}