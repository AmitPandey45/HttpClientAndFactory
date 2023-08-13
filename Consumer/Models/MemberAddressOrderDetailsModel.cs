using Newtonsoft.Json;

namespace Consumer.Models
{
    public class MemberAddressOrderDetailsModel
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("street")]
        public string FullAddress { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country_id")]
        public string Country { get; set; }

        [JsonProperty("region_id")]
        public string State { get; set; }

        [JsonProperty("postcode")]
        public string ZipCode { get; set; }

        [JsonProperty("telephone")]
        public string PhoneNumber { get; set; }

        [JsonProperty("save_in_address_book")]
        public int SaveInAddressBook { get; set; } = 1;
    }
}
