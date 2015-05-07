using System;
using System.Collections.Generic;

public class GSM
{
    // Fields
    private string model, manufacturer, owner;
    private uint price;
    private Battery battery;
    private Display display;
    private List<Call> callHistory = new List<Call>();
    private static GSM iphone4S = new GSM("4S", "Apple", 500, new Battery("super battery", 300, 50, BatteryType.NiMH), new Display(3.5, 16000000));

    // Constructors
    public GSM(string model, string manufacturer)
        : this(model, manufacturer, 0, null, null, null)
    {
    }

    public GSM(string model, string manufacturer, uint price)
        : this(model, manufacturer, price, null, null, null)
    {
    }

    public GSM(string model, string manufacturer, uint price, Battery battery)
        : this(model, manufacturer, price, battery, null, null)
    {
    }

    public GSM(string model, string manufacturer, uint price, Battery battery, Display display)
        : this(model, manufacturer, price, battery, display, null)
    {
    }

    public GSM(string model, string manufacturer, uint price, Battery battery, Display display, string owner)
    {
        this.model = model;
        this.manufacturer = manufacturer;
        this.Owner = owner;
        this.price = price;
        this.battery = battery;
        this.display = display;
    }

    // Properties, only owner can be assigned with invalid value, so we validate it
    // I use uint for everything so we don't have to check if given number is negative
    // i know that the price for example can be 499.99, but I made it uint
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        set { this.manufacturer = value; }
    }

    public string Owner
    {
        get { return this.owner; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                foreach (char ch in value)
                {
                    if (!char.IsLetter(ch) && !char.IsWhiteSpace(ch))
                    {
                        throw new ArgumentException("The name can contain only letters and white spaces");
                    }
                }
            }

            this.owner = value;
        }
    }

    public uint Price
    {
        get { return this.price; }
        set { this.price = value; }
    }

    public Battery Battery
    {
        get { return this.battery; }
        set { this.battery = value; }
    }

    public Display Display
    {
        get { return this.display; }
        set { this.display = value; }
    }

    public static GSM Iphone4S
    {
        get { return iphone4S; }
    }

    public List<Call> CallHistory
    {
        get { return this.callHistory; }
    }

    // Methods
    public override string ToString()
    {
        // Longest Format ever xD
        return string.Format("{0}Info{0}\n-Model: {2}\n-Manufacturer: {3}\n-Owner: {4}\n-Price: {5}\nBattery:\n{1}\n{6}\n{1}\nDisplay:\n{1}\n{7}\n{1}",
            new string('-', 8), new string('-', 20), this.model, this.manufacturer, this.owner == null ? "None" : this.owner, this.price,
            this.battery == null ? "No information" : this.battery.ToString(), this.display == null ? "No information" : this.display.ToString());
    }

    public void AddCallToHistory(Call call)
    {
        this.callHistory.Add(call);
    }

    public void RemoveCallFromHistory(Call call)
    {
        this.callHistory.Remove(call);
    }

    public void ClearCallHistory()
    {
        this.callHistory.Clear();
    }

    public decimal PriceOfCalls(decimal pricePerMinute)
    {
        decimal price = 0;
        foreach (Call call in this.callHistory)
        {
            price += (call.Duration / 60M) * pricePerMinute;
        }

        return Math.Round(price, 2);
    }
}