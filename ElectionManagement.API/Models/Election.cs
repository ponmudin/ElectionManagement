namespace ElectionManagement.API.Models
{
    public class Election
    {
        public int VoterId { get; set; }
        public int CandidateId { get; set; }
        public DateTime VotedDateTime { get; set; }

    }
}
