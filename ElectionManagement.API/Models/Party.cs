namespace ElectionManagement.API.Models
{
    public class Party
    {
        public int PartyId { get; set; }
        public string PartyName { get; set; } = string.Empty;
        public string PartySymbol { get; set; } = string.Empty;
    }
}
