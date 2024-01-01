using NetMQ;
using NetMQ.Sockets;

namespace NetMQServer
{
    public class Server
    {
        public void Listen(string name)
        {
            using (var server = new ResponseSocket("@tcp://*:12345")) // listening on port 12345
            {
                Console.WriteLine($"{name} is waiting for messages...");

                while (true)
                {
                    // Receive a message
                    string messageText = server.ReceiveFrameString();
                    ServerMessage? message = ServerMessage.DeserializeFromJson(messageText);

                    if (message?.Text == "end")
                        break;

                    message?.Print();

                    // Reply for client
                    server.SendFrame($"Message received at {name}");
                }
            }
        }
    }
}
