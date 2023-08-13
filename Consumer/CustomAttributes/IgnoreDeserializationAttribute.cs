namespace Consumer.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreDeserializationAttribute : Attribute
    {
    }
}
