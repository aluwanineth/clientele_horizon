using System.ComponentModel;

namespace Polly_C.Horizon.Models.v1
{
    public class BenefitV1
    {
        [JsonProperty(Required = Required.Always)]
        public string BenefitName { get; set; }
        [Description("Benefit code defined by Clientele. Refer to schema document.")]
        [JsonProperty(Required = Required.Always)]
        public string BenefitCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        [DataType(DataType.Currency)]
        public decimal CoverAmount { get; set; }
        [JsonProperty(Required = Required.Always)]
        [DataType(DataType.Currency)]
        public decimal Premium { get; set; }
        [JsonProperty(Required = Required.Always)]
        [EnumDataType(typeof(ConfigStatusV1))]
        public ConfigStatusV1 Status { get; set; }
    }
}
