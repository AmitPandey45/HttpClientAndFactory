using Consumer.CustomAttributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Consumer.CustomResolvers
{
    public class IgnoreDeserializationContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            var ignoreAttribute = member.GetCustomAttribute<IgnoreDeserializationAttribute>();
            if (ignoreAttribute != null)
            {
                property.ShouldDeserialize = _ => false;
            }

            return property;
        }
    }
}
