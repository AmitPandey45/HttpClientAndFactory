using Newtonsoft.Json;

namespace Consumer.Models.Custom
{
    public class OrderProductDetailsModel
    {
        [JsonProperty("product_sku")]
        public string ProductSku { get; set; }

        [JsonProperty("qty")]
        public int Quantity { get; set; }
    }
}
