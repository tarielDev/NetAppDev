using NetMQ;
using NetMQ.Sockets;

namespace NetMQClient
{
    public class Client
    {
        public void SendMessage(string fromUser)
        {
            using (var client = new RequestSocket("tcp://127.0.0.1:12345")) // connect to server
            {
                string? msg = default;

                do
                {
                    Console.WriteLine("\nEnter the message for server: ");
                    msg = Console.ReadLine();

                    ClientMessage message = new ClientMessage() { Text = msg, Date = DateTime.Now, NickNameFrom = fromUser, NickNameTo = "Server" };
                    string jsonTxt = message.SerializeMessageToJson();
                    client.SendFrame(jsonTxt);

                    if (message?.Text == "end")
                        break;

                    message?.Print();

                    // Receive reply from server
                    string reply = client.ReceiveFrameString();
                    Console.WriteLine($"Received reply: {reply}");

                }
                while (msg != "end");
            }
        }
    }
}
