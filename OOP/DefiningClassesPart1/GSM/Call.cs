using System;

public class Call
{
    // Fields
    private DateTime dateAndTime;
    private string dialedPhone;
    private uint duration;

    // Constructors
    public Call(DateTime dateAndTime, string dialedPhone)
        : this(dateAndTime, dialedPhone, 0)
    {
    }

    public Call(DateTime dateAndTime, string dialedPhone, uint duration)
    {
        this.dateAndTime = dateAndTime;
        this.dialedPhone = dialedPhone;
        this.duration = duration;
    }

    // Properties
    public DateTime Date
    {
        get { return this.dateAndTime.Date; }
    }

    public TimeSpan Time
    {
        get { return this.dateAndTime.TimeOfDay; }
    }

    public uint Duration
    {
        get { return this.duration; }
    }

    // Methods
    public override string ToString()
    {
        return string.Format("Date and time of the call: {0}\nDialed phone number: {1}\nDuration: {2}",
            this.dateAndTime.ToString(), this.dialedPhone, this.duration);
    }
}