using Microsoft.AspNetCore.SignalR.Client;
namespace ChatProject.Classerne
{

    public class SRClient
    {
        public HubConnection connection;
        public SRClient()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7129/Hubs/Chathub.cs")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }
    }
}
