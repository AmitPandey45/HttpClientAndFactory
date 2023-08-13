using Newtonsoft.Json;

namespace Consumer.Models
{
    public class CreateMemberOrderDetailsModel
    {
        [JsonProperty("membership_id")]
        public string AccountNumber { get; set; }

        [JsonProperty("mcs_refid")]
        public string MCSUniqueId { get; set; }

        [JsonIgnore]
        [JsonProperty("billing_address")]
        public List<MemberAddressOrderDetailsModel> BillingAddress { get; set; }

        [JsonProperty("shipping_address")]
        [JsonIgnore]
        public List<MemberAddressOrderDetailsModel> ShippingAddress { get; set; }

        [JsonProperty("items")]
        public List<OrderProductDetailsModel> OrderItems { get; set; }
    }
}
