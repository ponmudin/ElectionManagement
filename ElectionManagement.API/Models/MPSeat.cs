using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json.Serialization;
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

       
    }
}
