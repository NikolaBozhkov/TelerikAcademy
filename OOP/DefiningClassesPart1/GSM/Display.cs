using System;

public class Display
{
    // Fields
    private double size, numberOfColors;

    // Constructors
    public Display(double size)
        : this(size, 0)
    {
    }

    public Display(double size, double numberOfColors)
    {
        this.Size = size;
        this.numberOfColors = numberOfColors;
    }

    // Properties
    public double Size
    {
        get { return this.size; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("size cannot be 0 or less");
            }

            this.size = value;
        }
    }

    public double NumberOfColors
    {
        get { return this.numberOfColors; }
        set { this.numberOfColors = value; } 
    }

    // Methods
    public override string ToString()
    {
        return string.Format("-Size: {0}\n-Number of colors: {1}",
            this.size, this.numberOfColors);
    }
}