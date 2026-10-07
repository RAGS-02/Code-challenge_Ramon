using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppMultifuncional
{
    public class Calculadora : Form
    {
        private TextBox txtPantalla;
        private double valorAnterior = 0;
        private string operacionActual = "";
        private bool nuevaEntrada = true;

        public Calculadora()
        {
            Text = "Calculadora";
            Size = new Size(250, 350);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            txtPantalla = new TextBox
            {
                Dock = DockStyle.Top,
                Font = new Font("Arial", 20),
                TextAlign = HorizontalAlignment.Right,
                ReadOnly = true,
                Text = "0"
            };
            Controls.Add(txtPantalla);

            string[,] botones = {
                { "7", "8", "9", "/" },
                { "4", "5", "6", "*" },
                { "1", "2", "3", "-" },
                { "C", "0", "=", "+" }
            };

            int anchoBtn = 50, altoBtn = 50, padding = 10;

            for (int fila = 0; fila < 4; fila++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Button btn = new Button
                    {
                        Text = botones[fila, col],
                        Size = new Size(anchoBtn, altoBtn),
                        Location = new Point(padding + col * (anchoBtn + 5), 50 + fila * (altoBtn + 5)),
                        Font = new Font("Arial", 14)
                    };

                    if ("0123456789".Contains(btn.Text))
                        btn.Click += BtnNumero_Click;
                    else if ("+-*/".Contains(btn.Text))
                        btn.Click += BtnOperacion_Click;
                    else if (btn.Text == "=")
                        btn.Click += BtnIgual_Click;
                    else if (btn.Text == "C")
                        btn.Click += (s, e) => { txtPantalla.Text = "0"; valorAnterior = 0; operacionActual = ""; nuevaEntrada = true; };

                    Controls.Add(btn);
                }
            }
        }

        private void BtnNumero_Click(object sender, EventArgs e)
        {
            if (nuevaEntrada)
            {
                txtPantalla.Text = "";
                nuevaEntrada = false;
            }
            txtPantalla.Text += ((Button)sender).Text;
        }

        private void BtnOperacion_Click(object sender, EventArgs e)
        {
            valorAnterior = double.Parse(txtPantalla.Text);
            operacionActual = ((Button)sender).Text;
            nuevaEntrada = true;
        }

        private void BtnIgual_Click(object sender, EventArgs e)
        {
            if (operacionActual == "") return;

            double valorActual = double.Parse(txtPantalla.Text);
            double resultado = 0;

            switch (operacionActual)
            {
                case "+": resultado = valorAnterior + valorActual; break;
                case "-": resultado = valorAnterior - valorActual; break;
                case "*": resultado = valorAnterior * valorActual; break;
                case "/":
                    if (valorActual != 0) resultado = valorAnterior / valorActual;
                    else { txtPantalla.Text = "Error"; nuevaEntrada = true; return; }
                    break;
            }

            txtPantalla.Text = resultado.ToString();
            operacionActual = "";
            nuevaEntrada = true;
        }
    }
}