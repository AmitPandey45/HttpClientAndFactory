using Consumer.CustomAttributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Consumer.CustomResolvers
{
    public class IgnoreSerializationContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            var ignoreAttribute = member.GetCustomAttribute<IgnoreSerializationAttribute>();
            if (ignoreAttribute != null)
            {
                property.ShouldSerialize = _ => false;
            }

            return property;
        }
    }
}
