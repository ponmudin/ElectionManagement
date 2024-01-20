using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace ElectionManagement.API.Models
{
    public class MPSeat
    {
        public enum State
        {
            Tamilnadu,
            Kerala,
            Andrapradesh,
            Karnataka,
            Telengana,
            Maharashtra
        }

        public int ConstituencyId { get; set; }
        public string ConstituencyName { get; set; } = string.Empty;
        public int StateId { get; set; }

        public MPSeat(int constId, string constName, int stateId)
        {
            this.ConstituencyId = constId;
            this.ConstituencyName = constName;
            this.StateId = stateId;
        }
    }
}
