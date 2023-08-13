using Consumer.CustomResolvers;
using Consumer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CustomModels = Consumer.Models.Custom;

namespace Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonDeserializationController : ControllerBase
    {
        /// <summary>
        /// [JsonIgnore] handling both Serialization and Deserialization
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("withdefault")]
        public IActionResult GetDefaultJsonDeserializedData()
        {
            string jsonString = "{\"membership_id\":\"111111\",\"mcs_refid\":\"be498126-b0c3-4e97-850a-3c1751d60813\",\"billing_address\":[{\"firstname\":\"FName1\",\"lastname\":\"LName1\",\"street\":null,\"city\":\"Noida\",\"country_id\":\"IN\",\"region_id\":\"UP\",\"postcode\":\"231111\",\"telephone\":\"1234567890\",\"save_in_address_book\":1}],\"shipping_address\":[{\"firstname\":\"FName2\",\"lastname\":\"LName2\",\"street\":null,\"city\":\"Noida\",\"country_id\":\"IN\",\"region_id\":\"UP\",\"postcode\":\"231111\",\"telephone\":\"1234567890\",\"save_in_address_book\":1}],\"items\":[{\"product_sku\":\"MEMINDIVIDUAL23\",\"qty\":1}]}";

            var response = JsonConvert.DeserializeObject<CreateMemberOrderDetailsModel>(jsonString);

            return Ok(response);
        }

        [HttpGet]
        [Route("withcustom")]
        public IActionResult GetCustomJsonSerialzedData()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new IgnoreDeserializationContractResolver()
            };

            string jsonString = "{\"membership_id\":\"111111\",\"mcs_refid\":\"be498126-b0c3-4e97-850a-3c1751d60813\",\"billing_address\":[{\"firstname\":\"FName1\",\"lastname\":\"LName1\",\"street\":null,\"city\":\"Noida\",\"country_id\":\"IN\",\"region_id\":\"UP\",\"postcode\":\"231111\",\"telephone\":\"1234567890\",\"save_in_address_book\":1}],\"shipping_address\":[{\"firstname\":\"FName2\",\"lastname\":\"LName2\",\"street\":null,\"city\":\"Noida\",\"country_id\":\"IN\",\"region_id\":\"UP\",\"postcode\":\"231111\",\"telephone\":\"1234567890\",\"save_in_address_book\":1}],\"items\":[{\"product_sku\":\"MEMINDIVIDUAL23\",\"qty\":1}]}";

            var response = JsonConvert.DeserializeObject<CustomModels.CreateMemberOrderDetailsModel>(jsonString, settings);

            return Ok(response);
        }
    }
}
