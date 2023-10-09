using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpienteJuego
{
    class Casilla
    {
        protected int x, y, cuadro;
        public Casilla()
        {
            cuadro= 10;
        }
        public Boolean Interseccion(Casilla o)
        {
            int difx = Math.Abs(this.x - o.x);
            int dify = Math.Abs(this.y - o.y);
            if (difx >= 0 && difx < cuadro && dify >= 0 && dify < cuadro)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
