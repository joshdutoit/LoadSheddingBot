namespace ClassLibrary;

[AttributeUsage(AttributeTargets.Field)]
public class EnumValue : Attribute
{
    private readonly string _value;
    
    public EnumValue(string value)
    {
        _value = value;
    }

    public string GetValue()
    {
        return _value;
    }
    
    public static string GetValue(Enum value)
    {
        var type = value.GetType();
        var info = type.GetField(value.ToString());

        if (info == null) return null;
        if (info.GetCustomAttributes(typeof(EnumValue), false) is EnumValue[] {Length: > 0} attrs)
        {
            return attrs.First().GetValue();
        }
        
        return null;
    }
}