using ModelsDLL;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

List<Car> list = null!;

if (File.Exists("Cars.json"))
    list = JsonSerializer.Deserialize<List<Car>>(File.ReadAllText("Cars.json"));

var listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 45678);

listener.Start(10);

while (true)
{
    var client = await listener.AcceptTcpClientAsync();

    Console.WriteLine($"Client {client.Client.RemoteEndPoint} accepted");

    new Task(() =>
    {
        var stream = client.GetStream();
        var bw = new BinaryWriter(stream);
        var br = new BinaryReader(stream);

        while (true)
        {
            var jsonStr = br.ReadString();

            var command = JsonSerializer.Deserialize<Command>(jsonStr);

            if (command is null)
                continue;

            switch (command.Method)
            {
                case HttpMethods.GET:
                    {

                        break;
                    }
                case HttpMethods.POST:
                    break;
                case HttpMethods.PUT:
                    break;
                case HttpMethods.DELETE:
                    break;
                default:
                    break;
            }
        }
    }).Start();
}