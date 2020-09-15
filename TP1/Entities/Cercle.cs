using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Entities
{
    public class Cercle : Forme
    {
        private int rayon;

        public int Rayon { get => rayon; set => rayon = value; }

        public override double Aire()
        {
            return Math.PI * Math.Pow(Rayon, 2);
        }

        public override double Perimetre()
        {
            return 2 * Math.PI * Rayon;

        }
        public override string ToString()
        {
            return String.Format("Cercle de rayon {0} \nAire =  {1} \nPerimetre =  {2} \n", Rayon, Aire(), Perimetre());
        }



    }
}

