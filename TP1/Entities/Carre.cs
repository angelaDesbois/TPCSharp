using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Entities
{
    public class Carre : Forme
    {
        private int longueur;

        public int Longueur { get => longueur; set => longueur = value; }

        public override double Aire()
        {
            return Math.Pow(Longueur, 2);
        }

        public override double Perimetre()
        {
            return Longueur * 4;
        }

        public override string ToString()
        {
            return String.Format("Carré de coté = {0}  \nAire = {1}  \nPerimetre =  {2} \n", this.Longueur, Aire(), Perimetre());
        }
    }
}
