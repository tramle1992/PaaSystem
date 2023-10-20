using Core.Application.Data.ClientInfo;
namespace PaaApplication.Models.ClientInfo
{
    public class ClientUpdatedEventArgs
    {
        public ClientData Client { get; set; }

        public ClientUpdatedEventArgs(ClientData client)
        {
            this.Client = client;
        }

    }
}