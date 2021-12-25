using System;
using System.Windows.Forms;

namespace Task5
{
    public class FormalCostume : Clothes
    {
         public Char Sex { get; set; }
         public Int32 NumberOfButtons { get; set; }

         public void IronIt()
         {
             String message = "You successfully ironed this element of clothing:\n" + this.ToString();
             MessageBox.Show(message);
         }

         public void CrumpleIt()
         {
             String message = "You successfully crumpled this element of clothing:\n" + this.ToString();
             MessageBox.Show(message);
         }

         public override string ToString()
         {
             return "formal costume for " + Sex + " with " + NumberOfButtons.ToString() + " buttons, " + base.ToString();
         }
    }
}