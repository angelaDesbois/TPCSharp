using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Entities
{
    public class Triangle : Forme
    {
        private int a;
        private int b;
        private int c;

        public int A { get => a; set => a = value; }
        public int B { get => b; set => b = value; }
        public int C { get => c; set => c = value; }

        public override double Aire()
        {
            double p = Perimetre() / 2;
            return Math.Sqrt(p * (p - this.A) *(p - this.B) *(p - this.C));
          
         }

        public override double Perimetre()
        {
            return this.A + this.B + this.C;
        }

        public override string ToString()
        {
            return String.Format("Triangle de coté A = {0} B = {1} C = {2} \nAire = {3}  \nPerimetre =  {4} \n", this.A,this.B, this.C, Aire(), Perimetre());
        }
    }
}
