namespace Panaderia_DonDonas_NET_Core.DTOs
{
    public class AutenticationResponse
    {
        public string Token { get; set; }
        public DateTime expiration { get; set; }
    }
}
