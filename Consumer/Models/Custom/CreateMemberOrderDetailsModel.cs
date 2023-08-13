using Consumer.CustomAttributes;
using Newtonsoft.Json;

namespace Consumer.Models.Custom
{
    public class CreateMemberOrderDetailsModel
    {
        [JsonProperty("membership_id")]
        public string AccountNumber { get; set; }

        [JsonProperty("mcs_refid")]
        public string MCSUniqueId { get; set; }

        [JsonProperty("billing_address")]
        [IgnoreSerialization]
        [IgnoreDeserialization]
        public List<MemberAddressOrderDetailsModel> BillingAddress { get; set; }

        [JsonProperty("shipping_address")]
        [IgnoreSerialization]
        [IgnoreDeserialization]
        public List<MemberAddressOrderDetailsModel> ShippingAddress { get; set; }

        [JsonProperty("items")]
        public List<OrderProductDetailsModel> OrderItems { get; set; }
    }
}
