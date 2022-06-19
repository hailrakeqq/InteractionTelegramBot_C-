using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace RpTgBot
{
    public class GetRequest
    {
        HttpWebRequest _request;
        string _address;
        public string Responce { get; set; }

        public GetRequest(string address) { _address = address; }

        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_address);
            _request.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Responce = new StreamReader(stream).ReadToEnd();
            }
            catch (System.Exception)
            {
            }
        }
    }
    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5588675170:AAGTX_OfDlO89uYqvwY7YBhAvniaMHD_TvA");//5190518463:AAGNE1wPN3c9-suWfXGMgq8prQ9VZaAIEuk
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                var user = message.From.FirstName;
                string requestType;
                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, $"Добро пожаловать {message.From.FirstName}!!!\nДля того что бы узнать как использовать команды бота используйте /help");
                    return;
                }
                if (message.Text.ToLower() == "/help")
                {
                    await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: $"Привет {message.From.FirstName}, это помощь по командам этого миленького бота\n\nСписок всех команд которые имеет этот бот:\n\n/bite @user- укусить пользователя\n/blush - покраснеть\n/cry - плакать\n/cuddle @user - прижаться к пользователю\n/dance - танцевать\n/happy - радоваться\n/hit @user - ударить пользователя\n/hug @user - обнять пользователя\n/kill @user - убить пользователя\n/kiss @user - поцеловать пользователя\n/lick @user - облизать пользователя\n/pat @user - погладить пользователя\n/poke @user - тыкнуть пользователя\n/sad - грустить\n/smile - улыбнуться\n/wave @user - Приветствовать пользователя\n/wink @user - подмигнуть пользователю\n\n@user - это пользователь с которым вы хотите взаимодействовать",
                        disableNotification: true,
                        replyToMessageId: message.MessageId);
                    return;
                }
                if (message.Text.ToLower() == "/cry")
                {
                    requestType = "cry";
                    var request = new GetRequest($"https://api.otakugifs.xyz/gif?reaction={requestType}&format=gif");
                    request.Run();
                    var response = request.Responce;
                    var json = JObject.Parse(response);
                    var gif = json["url"].ToString();
                    await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: gif,
                        caption: $"{user} плачет..",
                        cancellationToken: cancellationToken);
                }
                if (message.Text.ToLower() == "/blush")
                {
                    requestType = "blush";
                    var request = new GetRequest($"https://api.otakugifs.xyz/gif?reaction={requestType}&format=gif");
                    request.Run();
                    var response = request.Responce;
                    var json = JObject.Parse(response);
                    var gif = json["url"].ToString();
                    await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: gif,
                        caption: $"{user} покраснел",
                        cancellationToken: cancellationToken);
                }
                if (message.Text.ToLower() == "/dance")
                {
                    requestType = "dance";
                    var request = new GetRequest($"https://api.otakugifs.xyz/gif?reaction={requestType}&format=gif");
                    request.Run();
                    var response = request.Responce;
                    var json = JObject.Parse(response);
                    var gif = json["url"].ToString();
                    await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: gif,
                        caption: $"{user} танцует!!",
                        cancellationToken: cancellationToken);
                }
                if (message.Text.ToLower() == "/happy")
                {
                    requestType = "happy";
                    var request = new GetRequest($"https://api.otakugifs.xyz/gif?reaction={requestType}&format=gif");
                    request.Run();
                    var response = request.Responce;
                    var json = JObject.Parse(response);
                    var gif = json["url"].ToString();
                    await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: gif,
                        caption: $"Солнышко {user} радуется!!",
                        cancellationToken: cancellationToken);
                }
                if (message.Text.ToLower() == "/sad")
                {
                    requestType = "sad";
                    var request = new GetRequest($"https://api.otakugifs.xyz/gif?reaction={requestType}&format=gif");
                    request.Run();
                    var response = request.Responce;
                    var json = JObject.Parse(response);
                    var gif = json["url"].ToString();
                    await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: gif,
                        caption: $"{user} грустит, поддержите солнышко:3",
                        cancellationToken: cancellationToken);
                }
                if (message.Text.ToLower() == "/smile")
                {
                    requestType = "smile";
                    var request = new GetRequest($"https://api.otakugifs.xyz/gif?reaction={requestType}&format=gif");
                    request.Run();
                    var response = request.Responce;
                    var json = JObject.Parse(response);
                    var gif = json["url"].ToString();
                    await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: gif,
                        caption: $"{user} улыбнулся!",
                        cancellationToken: cancellationToken);
                }
                if (message.Text.ToLower() == $"/bite {message.From.FirstName}")
                {
                    requestType = "bite";
                    var request = new GetRequest($"https://api.otakugifs.xyz/gif?reaction={requestType}&format=gif");
                    request.Run();
                    var response = request.Responce;
                    var json = JObject.Parse(response);
                    var gif = json["url"].ToString();
                    await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: gif,
                        caption: $"{user} укусил",
                        cancellationToken: cancellationToken);
                }


            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(ErrorMessage);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}