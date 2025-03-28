using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace FilaHospital.Hubs
{
    public class TicketHub : Hub
    {
        private static int _senhaAtual = 0;

        public async Task ChamarProximaSenha()
        {
            _senhaAtual++;
            await Clients.All.SendAsync("SenhaAtualizada", _senhaAtual);
        }

        public async Task ObterSenhaAtual()
        {
            await Clients.Caller.SendAsync("SenhaAtualizada", _senhaAtual);
        }
    }
}
