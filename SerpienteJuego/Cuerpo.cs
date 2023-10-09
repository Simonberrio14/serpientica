using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpienteJuego
{
    class Cuerpo : Casilla
    {
        Cuerpo siguiente;

        public Cuerpo(int x, int y)
        {
            this.x = x;
            this.y = y;
            siguiente = null;
        }
        public void Dibujar(Graphics g)
        {
            if (siguiente != null)
            {
                siguiente.Dibujar(g);
            }
            g.FillRectangle(new SolidBrush(Color.Green), this.x, this.y, this.cuadro, this.cuadro);
        }
        public void MoverXY(int x, int y)
        {
            if (siguiente != null)
            {
                siguiente.MoverXY(this.x, this.y);
            }
            this.x = x;
            this.y = y;
        }
        public void Meter()
        {
            if (siguiente == null)
            {
                siguiente = new Cuerpo(this.x, this.y);
            }
            else
            {
                siguiente.Meter();
            }
        }
        public int VerX()
        {
            return this.x;
        }
        public int VerY()
        {
            return this.y;
        }
        public Cuerpo VerSiguiente()
        {
            return siguiente;
        }
    }
}
