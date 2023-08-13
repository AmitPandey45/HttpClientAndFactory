using Newtonsoft.Json;

namespace Consumer.Models
{
    public class OrderProductDetailsModel
    {
        [JsonProperty("product_sku")]
        public string ProductSku { get; set; }

        [JsonProperty("qty")]
        public int Quantity { get; set; }
    }
}
