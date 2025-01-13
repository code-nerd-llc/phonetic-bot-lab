# Phonetic Alphabet Bot
Attempt at using Microsoft Bot Framework. Simple bot to translate input into phonetic alphabet.

Bot is currently channeled with [Telegram](https://t.me/phonetic_aplha_bot).

## Deployment and Usage

### Prerequisites
* [Bot Framework Emulator](https://github.com/microsoft/BotFramework-Emulator/blob/master/README.md)
* [Bot Framework SDK Templates](https://marketplace.visualstudio.com/items?itemName=BotBuilder.botbuilderv4)
* An Azure account that has an active subscription.
* An installation of the [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli).

### Usage

Project should run as is (no configuration needed). To run the project, open the project in Visual Studio/VSCode/Rider and press F5. This will start the bot.
Run Bot Emulator locally, click on Open Bot button and enter the URL of the bot (usually `http://localhost:3978/api/messages`). Bot should now be running, and you can interact with it.

### Deployment

To provision and publish a bot project includes 2 set of templates and parameter files:
* Existing Resource Group [link](https://github.com/code-nerd-llc/phonetic-bot-lab/tree/master/Deployment/Templates/DeployUseExistResourceGroup)
* New Resource Group [link](https://github.com/code-nerd-llc/phonetic-bot-lab/tree/master/Deployment/Templates/DeployWithNewResourceGroup)

Follow Microsoft documentation on how to deploy a bot to Azure [here](https://learn.microsoft.com/en-us/azure/bot-service/provision-and-publish-a-bot?view=azure-bot-service-4.0&tabs=userassigned%2Ccsharp#plan-your-deployment).


### Telegram Integration

To integrate the bot with Telegram, follow Microsoft documentation [here](https://learn.microsoft.com/en-us/azure/bot-service/bot-service-channel-connect-telegram?view=azure-bot-service-4.0).