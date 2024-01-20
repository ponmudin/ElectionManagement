namespace ElectionManagement.API.Models
{
    public class Voter
    {
        public int VoterId { get; set; } 
        public string VoterName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Photo { get; set; }=string.Empty;
        public int StateId { get; set; }
        public int ConstituencyId { get; set; }
        public bool IsApproved { get; set; }
    }
}
