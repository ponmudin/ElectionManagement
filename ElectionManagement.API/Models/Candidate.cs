using System.ComponentModel.DataAnnotations;

namespace ElectionManagement.API.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        //[Required]
        public string CandidateName { get; set; } = string.Empty;
        public int PartyId { get; set; }
        public int ConstituencyId { get; set; }
    }
}
