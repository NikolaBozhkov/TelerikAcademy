using System;

public class Battery
{
    // Fields
    private string model;
    private uint hoursIdle, hoursTalk;
    private BatteryType batteryType;

    // Constructors
    public Battery(string model)
        : this(model, 0, 0, BatteryType.None)
    {
    }

    public Battery(string model, uint hoursIdle, uint hoursTalk)
        : this(model, hoursIdle, hoursTalk, BatteryType.None)
    {
    }

    public Battery(string model, uint hoursIdle, uint hoursTalk, BatteryType batteryType)
    {
        this.model = model;
        this.hoursIdle = hoursIdle;
        this.hoursTalk = hoursTalk;
        this.batteryType = batteryType;
    }

    // Properties
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public uint HoursIdle
    {
        get { return this.hoursIdle; }
        set { this.hoursIdle = value; }
    }

    public uint HoursTalk
    {
        get { return this.hoursTalk; }
        set { this.hoursTalk = value; }
    }

    public BatteryType BatteryType
    {
        get { return this.batteryType; }
        set { this.batteryType = value; }
    }

    // Methods
    public override string ToString()
    {
        return string.Format("-Model: {0}\n-Hours idle: {1}\n-Hours talk: {2}\n-Battery type: {3}",
            this.model, this.hoursIdle, this.hoursTalk, this.batteryType);
    }
}

public enum BatteryType
{
    None,
    Li_Ion,
    NiMH,
    NiCd
}