using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace PhoneticBot.Bots;

public class PhoneticAlphabetBot : ActivityHandler
{
    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext,
        CancellationToken cancellationToken)
    {
        var inputText = turnContext.Activity.Text.ToLower();
        // Phonetic alphabet dictionary
        var phoneticAlphabet = new Dictionary<char, string>
        {
            { 'a', "alpha" }, { 'b', "bravo" }, { 'c', "charlie" }, { 'd', "delta" },
            { 'e', "echo" }, { 'f', "foxtrot" }, { 'g', "golf" }, { 'h', "hotel" },
            { 'i', "india" }, { 'j', "juliett" }, { 'k', "kilo" }, { 'l', "lima" },
            { 'm', "mike" }, { 'n', "november" }, { 'o', "oscar" }, { 'p', "papa" },
            { 'q', "quebec" }, { 'r', "romeo" }, { 's', "sierra" }, { 't', "tango" },
            { 'u', "uniform" }, { 'v', "victor" }, { 'w', "whiskey" }, { 'x', "x-ray" },
            { 'y', "yankee" }, { 'z', "zulu" }
        };

        // Split input into words and translate each word to its phonetic representation
        var words = inputText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var translatedWords = words.Select((word, index) =>
        {
            var translatedWord = string.Join(" ",
                word.Select(c => phoneticAlphabet.TryGetValue(c, out var value) ? value : c.ToString()));
            return $"{index + 1}. {translatedWord}";
        });

        // Join the translated words into numbered lines
        var translatedText = string.Join("\n", translatedWords);

        // Send the translated text as the bot's response
        await turnContext.SendActivityAsync(MessageFactory.Text(translatedText), cancellationToken);
    }

    protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded,
        ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
    {
        const string welcomeText = "Hello and welcome! This bot translates your messages into the phonetic alphabet.";
        foreach (var member in membersAdded)
        {
            if (member.Id != turnContext.Activity.Recipient.Id)
            {
                await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
            }
        }
    }
}