namespace Polly_C.Horizon.Models.v1
{
    public class BankingDetailsV1
    {
        [JsonProperty(Required = Required.Default)]
        [Range(1, 31)]
        public int DebitDay { get; set; }
        [JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string BankName { get; set; }
        public string? BranchCodeName { get; set; }
        [JsonProperty(Required = Required.Always)]
        public int BranchCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public int AccountNumber { get; set; }
        [JsonProperty(Required = Required.Default)]
        [EnumDataType(typeof(PaymentMethodV1))]
        public PaymentMethodV1 PaymentMethod { get; set; }
        [JsonProperty(Required = Required.Always)]
        [EnumDataType(typeof(BankAccountTypeV1))]
        public BankAccountTypeV1 BankAccountType { get; set; }
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? AccountHolder { get; set; }
    }
}
