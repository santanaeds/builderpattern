using SearchAPI.Extensions;
using System.Text.Json.Serialization;

namespace SearchAPI.Models
{
    public class ActionsToTakeItem
    {
        [JsonConverter(typeof(TolerantEnumConverter))]
        public ActionsToTake Action { get; set; }
        public string ActionDescription => Action.Description();
        public int MetCriteria { get; set; } = 0;
        public int Total { get; set; } = 0;
        public string LabelValue => $"{MetCriteria}/{Total}";
    }
}
