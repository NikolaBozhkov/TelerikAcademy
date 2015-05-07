using System;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
    AttributeTargets.Interface | AttributeTargets.Enum |
    AttributeTargets.Method, AllowMultiple = false)]
public class VersionAttribute : Attribute
{
    // Major and manor can be manipulated, but they are int so no problem
    public int Major { get; set; }
    public int Manor { get; set; }
    public string Version 
    {
        get { return string.Format("{0}.{1}", Major, Manor); }
    }

    public VersionAttribute(string version)
    {
        // Always get valid version
        try
        {
            string[] parts = version.Split('.');
            this.Major = int.Parse(parts[0]);
            this.Manor = int.Parse(parts[1]);
        }
        catch
        {
            throw new FormatException("Version must be in the format \"major.manor\".");
        }
    }
}