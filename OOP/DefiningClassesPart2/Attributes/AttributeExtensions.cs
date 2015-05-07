using System;
using System.Linq;

public static class AttributeExtensions
{
    /// <summary>
    /// It's an elegant solution I found in the net
    /// We create extension for the Attribute class
    /// We get our attribute and by the given function
    /// return a value(if it is not null, otherwise return the default)
    /// </summary>
    public static TValue GetAttributeValue<TAttribute, TValue>(
        this Type type,
        Func<TAttribute, TValue> valueSelector)
        where TAttribute : Attribute
    {
        var attribute = type.GetCustomAttributes(typeof(TAttribute),
            true).FirstOrDefault() as TAttribute;
        if (attribute != null)
        {
            return valueSelector(attribute);
        }

        return default(TValue);
    }
}