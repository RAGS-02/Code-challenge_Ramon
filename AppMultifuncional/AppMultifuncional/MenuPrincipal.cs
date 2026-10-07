using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppMultifuncional
{
    public class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            Text = "Menú Principal";
            Size = new Size(300, 250);
            StartPosition = FormStartPosition.CenterScreen;

            Button btnEditor = new Button { Text = "1. Editor de Texto", Dock = DockStyle.Top, Height = 50 };
            Button btnPaint = new Button { Text = "2. Paint Básico", Dock = DockStyle.Top, Height = 50 };
            Button btnCalculadora = new Button { Text = "3. Calculadora", Dock = DockStyle.Top, Height = 50 };

            btnEditor.Click += (s, e) => new EditorTexto().ShowDialog();
            btnPaint.Click += (s, e) => new PaintBasico().ShowDialog();
            btnCalculadora.Click += (s, e) => new Calculadora().ShowDialog();

            Controls.Add(btnCalculadora);
            Controls.Add(btnPaint);
            Controls.Add(btnEditor);
        }
    }
}