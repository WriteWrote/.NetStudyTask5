using System;
using System.Drawing;

namespace Task5
{
    public abstract class Clothes : ITextile
    {
        public Int32 Size { get; set; }
        public Season Season { get; set; }
        public Style Style { get; set; }
        public Color Color { get; set; }

        public void Buy()
        {
            String message = "You successfully bought this element of clothing: " + this.ToString();
        }

        public void Sell()
        {
            String message = "You successfully sold this element of clothing: " + this.ToString();
        }

        public void Dispose()
        {
            String message = "You successfully disposed of this element of clothing: " + this.ToString();
        }

        public override string ToString()
        {
            return "size " + this.Size + ", " + Color + " color, for " + Season + " in " + Style + " style";
        }
    }
}