using System;
using System.Windows.Forms;

namespace Task5
{
    public class HalloweenCostume : Clothes
    {
        public String MonsterDescr { get; set; }
        public HumanType HumanType { get; set; }

        public void MovetoDustyBox()
        {
            String message = "You moved to dusty box til next year this element of clothing:\n" + this.ToString();
            MessageBox.Show(message);
        }

        public void ScarePeople()
        {
            String message = "You successfully scared the hell out of neighbours in this element of clothing:\n" +
                             this.ToString();
            String message2 = "Вы напугали деда в \n" + this.ToString();
            MessageBox.Show(message2);
        }

        public override string ToString()
        {
            return "Halloween costume of " + MonsterDescr + " for " + HumanType + ", " + base.ToString();
        }
    }
}