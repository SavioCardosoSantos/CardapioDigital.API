namespace CardapioDigital.Application.DTOs.ChatGPT
{
    public class ChatGptChoices
    {
        public int Index { get; set; }
        public ChatGptMessage Message { get; set; }
        public string Finish_reason { get; set; }
    }
}
