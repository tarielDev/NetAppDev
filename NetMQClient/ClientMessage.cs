using System.Text.Json;

namespace NetMQClient
{
    public class ClientMessage
    {
        public string? Text { get; set; }
        public DateTime Date { get; set; }
        public string? NickNameFrom { get; set; }
        public string? NickNameTo { get; set; }
        public string SerializeMessageToJson() => JsonSerializer.Serialize(this);

        public static ClientMessage? DeserializeFromJson(string message) => JsonSerializer.Deserialize<ClientMessage>(message);
        public void Print()
        {
            Console.WriteLine($"\nDate: {this.Date} \nsent: '{this.Text}' \nfrom: {this.NickNameFrom}");
        }
    }
}
