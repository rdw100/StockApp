using StockApp.Shared.Authentication.Models;

namespace StockApp.Client.Authentication.Models
{
    public class UserAuthenticationState
    {
        public ClientPrincipal? ClientPrincipal { get; set; }
    }
}
