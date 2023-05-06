namespace Polly_C.Horizon.Models.v1
{
    public class EntityV1
    {
        [JsonProperty(Required = Required.Always)]
        [EnumDataType(typeof(PolicyEntityTypeV1))]
        public PolicyEntityTypeV1 EntityType { get; set; }
        [JsonProperty(Required = Required.Always)]
        public decimal? AllocationPercentage { get; set; }
        [JsonProperty(Required = Required.Default)]
        public AddressV1 PhysicalAddress { get; set; }
        [JsonProperty(Required = Required.Default)]
        public AddressV1 PostalAddress { get; set; }
        [JsonProperty(Required = Required.Always)]
        public ContactDetailsV1 ContactDetails { get; set; }
        [JsonProperty(Required = Required.Always)]
        public PersonalDetailsV1 PersonalDetails { get; set; }
        [JsonProperty(Required = Required.Default)]
        public List<BenefitV1> Benefits { get; set; }
    }
}
