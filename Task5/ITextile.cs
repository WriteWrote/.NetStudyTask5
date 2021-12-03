using System.Drawing;

namespace Task5
{
    public interface ITextile
    {
        Color Color { get; set; }
        void Buy();
        void Sell();
        void Dispose();
    }
}