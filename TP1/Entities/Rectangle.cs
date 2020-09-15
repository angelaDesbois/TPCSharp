using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Entities
{
    public class Rectangle : Forme
    {

        private int longueur;
        private int largeur;

       

        public int Longueur { get => longueur; set => longueur = value; }
        public int Largeur { get => largeur; set => largeur = value; }

        public override double Aire()
        {
            return Longueur * Largeur;
        }

        public override double Perimetre()
        {
            return (Largeur * Longueur) * 2;
        }

        public override string ToString()
        {
            return String.Format("Rectangle de longueur = {0} et de largeur = {1} \nAire = {2}  \nPerimetre =  {3} \n", this.Longueur, this.Largeur, Aire(), Perimetre());
        }
    }
}
