global using Newtonsoft.Json;
global using Polly_C.Horizon.Models.Enums.v1;
global using System.ComponentModel.DataAnnotations;

namespace Polly_C.Horizon.Models.v1
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PolicyV1
    {
        [JsonProperty(Required = Required.Always)]
        public string Source { get; set; }
        [JsonProperty(Required = Required.Always)]
        [EnumDataType(typeof(ConfigStatusV1))]
        public ConfigStatusV1 Status { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string? SaleDivision { get; set; }
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? AgentName { get; set; }
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? AgentCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string SourcePolicyNumber { get; set; }
        [JsonProperty(Required = Required.Always)]
        public DateTime CaptureDate { get; set; }
        [JsonProperty(Required = Required.Always)]
        public DateTime NewInceptionDate { get; set; }
        [JsonProperty(Required = Required.Default)]
        public DateTime EffectiveDate { get; set; }
        [JsonProperty(Required = Required.Always)]
        public ProductV1 Product { get; set; }
        [JsonProperty(Required = Required.Always)]
        public List<EntityV1> Entities { get; set; }
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public BankingDetailsV1 BankingDetails { get; set; }
    }
}
