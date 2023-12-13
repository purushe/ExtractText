using System;

namespace TextReader.Models
{
  public class ChatMessage
  {
    public string Sender { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
  }

}
