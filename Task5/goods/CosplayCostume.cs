using System;

namespace Task5
{
    public class CosplayCostume : Clothes
    {
        public String Hero { get; set; }
        public String Fandom { get; set; }

        public void MakePhotosInIt()
        {
            String message = "You posed for some nice photos in this element of clothing: " + this.ToString();
        }

        public void PlayCosplayInIt()
        {
            String message = "You played " + Hero + " from " + Fandom + " on ComicCon in this element of clothing: " + this.ToString();
        }

        public override string ToString()
        {
            return "cosplay costume of " + Hero + " from, " + Fandom + ", " + base.ToString();
        }
    }
}