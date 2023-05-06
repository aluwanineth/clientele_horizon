using System.ComponentModel;

namespace Polly_C.Horizon.Models.v1
{
    public class ProductV1
    {
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string MasterContractProductCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string ProductCode { get; set; }
        [JsonProperty(Required = Required.Always)]        
        [Description("Total premium for policy")]
        [DataType(DataType.Currency)]
        public decimal Premium { get; set; }
        [JsonProperty(Required = Required.Always)]
        [Description("Partner code defined by Clientele. Refer to schema document.")]
        public int PartnerCD { get; set; }
        [JsonProperty(Required = Required.Always)]
        [Description("Scheme code defined by Clientele. Refer to schema document.")]
        public string SchemeCD { get; set; }
    }
}
