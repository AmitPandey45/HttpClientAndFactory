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
    public class JsonSerializationController : ControllerBase
    {
        /// <summary>
        /// Working fine with default json ignore attribute of NewtonSoft.Json
        /// If [JsonIgnore] and [JsonProperty("billing_address")] applied on same properties it is giving priority to [JsonIgnore]
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("withdefault")]
        public IActionResult GetDefaultJsonSerialzedData()
        {
            var data = new CreateMemberOrderDetailsModel
            {
                AccountNumber = "111111",
                MCSUniqueId = Guid.NewGuid().ToString(),
                BillingAddress = new List<MemberAddressOrderDetailsModel>
                {
                    new MemberAddressOrderDetailsModel
                    {
                        FirstName = "FName1",
                        LastName = "LName1",
                        PhoneNumber = "1234567890",
                        Country = "IN",
                        State = "UP",
                        City = "Noida",
                        ZipCode = "231111",
                    }
                },
                ShippingAddress = new List<MemberAddressOrderDetailsModel>
                {
                    new MemberAddressOrderDetailsModel
                    {
                        FirstName = "FName2",
                        LastName = "LName2",
                        PhoneNumber = "1234567890",
                        Country = "IN",
                        State = "UP",
                        City = "Noida",
                        ZipCode = "231111",
                    }
                },
                OrderItems = new List<OrderProductDetailsModel>
                {
                    new OrderProductDetailsModel
                    {
                        ProductSku = "MEMINDIVIDUAL23",
                        Quantity = 1
                    }
                }
            };

            var response = JsonConvert.SerializeObject(data);

            return Ok(response);
        }

        /// <summary>
        /// Working fine with custom json ignore serialization
        /// If applied to parent properties have complex type not looking for its child with only JsonProperty also
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("withcustom")]
        public IActionResult GetCustomJsonSerialzedData()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new IgnoreSerializationContractResolver()
            };

            var data = new CustomModels.CreateMemberOrderDetailsModel
            {
                AccountNumber = "111111",
                MCSUniqueId = Guid.NewGuid().ToString(),
                BillingAddress = new List<CustomModels.MemberAddressOrderDetailsModel>
                {
                    new CustomModels.MemberAddressOrderDetailsModel
                    {
                        FirstName = "FName1",
                        LastName = "LName1",
                        PhoneNumber = "1234567890",
                        Country = "IN",
                        State = "UP",
                        City = "Noida",
                        ZipCode = "231111",
                    }
                },
                ShippingAddress = new List<CustomModels.MemberAddressOrderDetailsModel>
                {
                    new CustomModels.MemberAddressOrderDetailsModel
                    {
                        FirstName = "FName2",
                        LastName = "LName2",
                        PhoneNumber = "1234567890",
                        Country = "IN",
                        State = "UP",
                        City = "Noida",
                        ZipCode = "231111",
                    }
                },
                OrderItems = new List<CustomModels.OrderProductDetailsModel>
                {
                    new CustomModels.OrderProductDetailsModel
                    {
                        ProductSku = "MEMINDIVIDUAL23",
                        Quantity = 1
                    }
                }
            };

            var response = JsonConvert.SerializeObject(data, settings);

            return Ok(response);
        }
    }
}
