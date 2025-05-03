namespace CardapioDigital.Application.DTOs.ChatGPT
{
    public class ChatGptResponse
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public string Model { get; set; }
        public List<ChatGptChoices> Choices { get; set; }
}
}
