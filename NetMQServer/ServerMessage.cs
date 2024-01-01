using System.Text.Json;

namespace NetMQServer
{
    public class ServerMessage
    {
        public string? Text { get; set; }
        public DateTime Date { get; set; }
        public string? NickNameFrom { get; set; }
        public string? NickNameTo { get; set; }

        public string SerializeMessageToJson() => JsonSerializer.Serialize(this);
        public static ServerMessage? DeserializeFromJson(string message) => JsonSerializer.Deserialize<ServerMessage>(message);
        public void Print()
        {
            Console.WriteLine($"\nDate: {this.Date} \nReceived: '{this.Text}' \nFrom: {this.NickNameFrom}");
        }
    }


}
