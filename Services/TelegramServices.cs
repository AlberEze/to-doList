namespace Agenda.Services
{
    public class TelegramServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _botToken;
        private readonly string _chatId;

        public TelegramServices(HttpClient httpClient, string botToken, string chatId)
        {
            _httpClient = httpClient;
            _botToken = botToken;
            _chatId = chatId;
        }

        public async Task SendMessageAsync(string message)
        {
            var url = $"https://api.telegram.org/bot{_botToken}/sendMessage?chat_id={_chatId}&text={message}";
            await _httpClient.GetAsync(url);
        }
    }
}
