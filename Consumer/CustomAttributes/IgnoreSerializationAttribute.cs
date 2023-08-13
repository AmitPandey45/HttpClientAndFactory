namespace Consumer.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreSerializationAttribute : Attribute
    {
    }
}
