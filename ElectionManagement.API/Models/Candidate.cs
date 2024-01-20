namespace ElectionManagement.API.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; } = string.Empty;
        public int PartyId { get; set; }
        public int ConstituencyId { get; set; }
        public int StateId { get; set; }
    }
}
