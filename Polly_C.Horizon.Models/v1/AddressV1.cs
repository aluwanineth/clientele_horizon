namespace Polly_C.Horizon.Models.v1
{
    public class AddressV1
    {
        [JsonProperty(Required = Required.Always)]
        public string AddressLine1 { get; set; }
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? AddressLine2 { get; set; }
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Suburb { get; set; }
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? City { get; set; }
        [JsonProperty(Required = Required.Always)]
        [MaxLength(4)]
        [RegularExpression(@"(^$)|(^\d{4}$)")]
        public string PostalCode { get; set; }
    }
}
