using Microsoft.AspNetCore.SignalR.Client;
using signalr.Client.Src.Models;
using System;
using System.Threading.Tasks;

namespace signalr.Client.Pages
{
    public partial class Index : IAsyncDisposable
    {
        private HubConnection? _hubConnection;
        private Productivity _productivity = new Productivity();

        protected override async Task OnInitializedAsync()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44329/productivityHub")
                .Build();

            _hubConnection.On<Productivity>("Productivity", (productivity) =>
            {
                _productivity = productivity;
                StateHasChanged();
            });
            await _hubConnection.StartAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.DisposeAsync();
            }
        }
    }
}