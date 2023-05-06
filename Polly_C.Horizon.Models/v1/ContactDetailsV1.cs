using System.Text.Json.Serialization;

namespace Polly_C.Horizon.Models.v1
{
    public class ContactDetailsV1
    {
        
        [MaxLength(10)]
        [RegularExpression(@"(^$)|(^\d{10}$)")]
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? HomeNumber { get; set; }
        [MaxLength(10)]
        [RegularExpression(@"(^$)|(^\d{10}$)")]
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? WorkNumber { get; set; }
        [MaxLength(10)]
        [RegularExpression(@"(^$)|(^\d{10}$)")]
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? MobileNumber { get; set; }
        [MaxLength(10)]
        [RegularExpression(@"(^$)|(^\d{10}$)")]
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]  
        public string? FaxNumber { get; set; }
        [RegularExpression(@"(^$|^.*@.*\..*$)")]
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? EmailAddress { get; set; }
    }
}
