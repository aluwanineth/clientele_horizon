namespace Polly_C.Horizon.Models.v1
{
    public class PersonalDetailsV1
    {
        [JsonProperty(Required = Required.Always)]
        public string FirstName { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string LastName { get; set; }
        [JsonProperty(Required = Required.Default)]
        public string? FullName { get; set; }
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? MaskedLegalReferenceNumber { get; set; }
        [JsonProperty(Required = Required.Default)]
        [DataType(DataType.Date)]
        public DateTime? DoB { get; set; }
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? LegalReferenceNumber { get; set; }
        [JsonProperty(Required = Required.Always)]
        public LegalReferenceNumberTypeV1 LegalReferenceNumberType { get; set; }
        [JsonProperty(Required = Required.Default)]
        public TitleV1 Title { get; set; }
        [JsonProperty(Required = Required.Default)]
        public GenderV1 Gender { get; set; }
        [JsonProperty(Required = Required.Default)]
        public SmokerV1 Smoker { get; set; }
        [JsonProperty(Required = Required.Default)]
        public PreferredCommTypeV1 PreferredCommType { get; set; }
    }
}
