using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerpienteJuego
{
    public partial class Form1 : Form
    {
        Cuerpo cabeza;
        Graphics g;
        int puntos = 0;
        Comida comida;
        int xdir = 0, ydir = 0;
        int cuadro = 10;
        Boolean ejeX = true, ejeY = true;
        public Form1()
        {
            InitializeComponent();
            cabeza = new Cuerpo(10, 10);
            comida = new Comida();
            g = PictureBox1.CreateGraphics();
        }
        public void movimiento()
        {
            cabeza.MoverXY(cabeza.VerX()+xdir, cabeza.VerY()+ydir);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bucle_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            cabeza.Dibujar(g);
            comida.Dibujar(g);
            movimiento();
            Chocar();
            Pared();
            if (cabeza.Interseccion(comida))
            {
                comida.Mostrar();
                cabeza.Meter();
                puntos = puntos + 10;
                label2.Text = Convert.ToString(puntos);
            }
        }
        public void GameOver()
        {
            puntos = 0;
            label2.Text = "0";
            ejeX = true;
            ejeY = true;
            xdir = 0;
            ydir = 0;
            cabeza = new Cuerpo(10, 10);
            comida = new Comida();
            MessageBox.Show("Game Over!");
        }
        public void Chocar()
        {
            Cuerpo temp;
            try
            {
                temp = cabeza.VerSiguiente();
            }catch(Exception err)
            {
                temp = null;
            }
            while(temp != null)
            {
                if (cabeza.Interseccion(temp))
                {
                    GameOver();
                }
                else
                {
                    temp = temp.VerSiguiente();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        public void Pared()
        {
            if (cabeza.VerX() < 0 || cabeza.VerX() > 530 || cabeza.VerY() < 0 || cabeza.VerY() > 400)
            {
                GameOver();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                bucle.Enabled = false;
            }
            if(e.KeyCode == Keys.R)
            {
                bucle.Enabled = true;
            }
            if (e.KeyCode == Keys.W)
            {
                Environment.Exit(0);
            }
            if(ejeX)
            {
                if (e.KeyCode == Keys.Up)
                {
                    ydir = -cuadro;
                    xdir = 0;
                    ejeX = false;
                    ejeY = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    ydir = cuadro;
                    xdir = 0;
                    ejeX = false;
                    ejeY = true;
                }
            }
            if (ejeY)
            {
                if (e.KeyCode == Keys.Right)
                {
                    ydir = 0;
                    xdir = cuadro;
                    ejeX = true;
                    ejeY = false;
                }
                if (e.KeyCode == Keys.Left)
                {
                    ydir = 0;
                    xdir = -cuadro;
                    ejeX = true;
                    ejeY = false;
                }
            }
        }
    }
}