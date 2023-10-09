using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SerpienteJuego
{
    class Comida : Casilla
    {
        int num;
        public Comida()
        {
            this.x = Generar(54);
            this.y = Generar(41);
        }
        public void Dibujar(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Purple), this.x, this.y, this.cuadro, this.cuadro);
        }
        public void Mostrar()
        {
            this.x = Generar(54);
            this.y = Generar(41);
        }
        public int Generar(int n)
        {
            Random random = new Random();
            num = random.Next(0, n) * 10;
            return num;
        }
    }
}
