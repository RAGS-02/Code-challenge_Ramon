using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppMultifuncional
{
    public class PaintBasico : Form
    {
        private PictureBox lienzo;
        private Bitmap dibujo;
        private Color colorActual = Color.Black;
        private bool dibujando = false;
        private Point puntoAnterior;

        public PaintBasico()
        {
            Text = "Paint Básico";
            Size = new Size(800, 600);

            Panel panelHerramientas = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = Color.LightGray };
            Button btnFondo = new Button { Text = "Fondo = Color Actual", Width = 150, Left = 10, Top = 5 };
            btnFondo.Click += (s, e) => lienzo.BackColor = colorActual;
            panelHerramientas.Controls.Add(btnFondo);

            // Paleta de colores
            Color[] colores = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.White };
            int offset = 170;
            foreach (Color c in colores)
            {
                Button btnColor = new Button { BackColor = c, Width = 30, Height = 30, Left = offset, Top = 5 };
                btnColor.Click += (s, e) => colorActual = btnColor.BackColor;
                panelHerramientas.Controls.Add(btnColor);
                offset += 35;
            }

            lienzo = new PictureBox { Dock = DockStyle.Fill, BackColor = Color.White };
            lienzo.MouseDown += (s, e) => { dibujando = true; puntoAnterior = e.Location; };
            lienzo.MouseUp += (s, e) => dibujando = false;
            lienzo.MouseMove += Lienzo_MouseMove;

            Controls.Add(lienzo);
            Controls.Add(panelHerramientas);

            Load += (s, e) => dibujo = new Bitmap(lienzo.Width, lienzo.Height);
        }

        private void Lienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dibujando && dibujo != null)
            {
                using (Graphics g = Graphics.FromImage(dibujo))
                {
                    Pen lapiz = new Pen(colorActual, 3);
                    g.DrawLine(lapiz, puntoAnterior, e.Location);
                }
                puntoAnterior = e.Location;
                lienzo.Image = dibujo;
            }
        }
    }
}